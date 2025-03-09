using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Timelive.Application.DTOs.Authentication;
using Timelive.Application.Interfaces;
using Timelive.Application.Settings;
using Timelive.Domain.Entities;
using Timelive.Domain.Interfaces;

namespace Timelive.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly JwtSettings _jwt;

    public AuthenticationService(
        IUserRepository userRepository,
        IOptions<JwtSettings> jwtOptions
    )
    {
        _userRepository = userRepository;
        _jwt = jwtOptions.Value;
    }

    public async Task<bool> CreateUserAsync(RegisterDto registerDto)
    {
        User newUser = new()
        {
            Email = registerDto.Email,
            Username = registerDto.Username,
            Password = HashPassword(registerDto.Password),
            Role = "user"
        };

        if (await _userRepository.GetUserByEmailAsync(newUser.Email) != null)
        {
            return false;
        }

        await _userRepository.AddAsync(newUser);
        await _userRepository.SaveChangesAsync();

        return true;
    }

    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        var user = await _userRepository.GetUserByEmailAndPasswordAsync(loginDto.Email, HashPassword(loginDto.Password));
        if (user == null)
        {
            return "";
        }

        user.Token = GenerateRefreshToken();
        _userRepository.Update(user);
        await _userRepository.SaveChangesAsync();

        return GenerateJwtToken(user.Id, user.Email!, user.Role!);
    }

    public async Task<string> UpdateRefreshTokenAsync(string email)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if (user == null)
        {
            return "";
        }

        user.Token = GenerateRefreshToken();
        _userRepository.Update(user);
        await _userRepository.SaveChangesAsync();

        return user.Token;
    }

    private static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        var hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

        return hashedPassword;
    }

    private string GenerateJwtToken(int userId, string email, string role)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwt.Secret ?? throw new ArgumentNullException("No JWT key found in configuration."));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            ]),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _jwt.Issuer,
            Audience = _jwt.Audience
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        var refreshToken = Convert.ToBase64String(randomNumber);

        return refreshToken;
    }
}
