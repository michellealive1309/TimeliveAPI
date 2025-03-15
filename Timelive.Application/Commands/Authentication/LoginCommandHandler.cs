using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Timelive.Application.DTOs.Authentication;
using Timelive.Application.Helpers;
using Timelive.Application.Interfaces;
using Timelive.Application.Settings;
using Timelive.Domain.Interfaces;

namespace Timelive.Application.Commands.Authentication;

public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResultDto>
{
    private readonly IUserRepository _userRepository;
    private readonly JwtSettings _jwt;

    public LoginCommandHandler(
        IUserRepository userRepository,
        IOptions<JwtSettings> options
    )
    {
        _userRepository = userRepository;
        _jwt = options.Value;
    }

    public async Task<LoginResultDto> Handle(LoginCommand command, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetUserByEmailAsync(command.Email);
        if (user == null || user.Password != PasswordHelper.HashPassword(command.Password))
        {
            return new LoginResultDto {};
        }

        user.Token = GenerateRefreshToken();
        _userRepository.Update(user);
        await _userRepository.SaveChangesAsync();

        return new LoginResultDto {
            AccessToken = GenerateJwtToken(user.Id, user.Email, user.Role.ToString()),
            RefreshToken = user.Token
        };
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
