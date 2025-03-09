using Timelive.Application.DTOs.Authentication;
using Timelive.Domain.Entities;

namespace Timelive.Application.Interfaces;

public interface IAuthenticationService
{
    Task<UserResponseDto> CreateUserAsync(RegisterDto registerDto);
    Task<string> LoginAsync(LoginDto loginDto);
    Task<string> UpdateRefreshTokenAsync(string email);
}
