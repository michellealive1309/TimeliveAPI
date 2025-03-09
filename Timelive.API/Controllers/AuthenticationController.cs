using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timelive.Application.DTOs.Authentication;
using Timelive.Application.Interfaces;

namespace Timelive.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> Signin([FromBody] LoginDto loginDto)
        {
            var accessToken = await _authenticationService.LoginAsync(loginDto);
            if (accessToken == "")
            {
                return Unauthorized();
            }

            var refreshToken = await _authenticationService.UpdateRefreshTokenAsync(loginDto.Email);
            Response.Cookies.Append("refresh_token", refreshToken, new CookieOptions {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(30)
            });

            return Ok(accessToken);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] RegisterDto registerDto)
        {
            var result = await _authenticationService.CreateUserAsync(registerDto);

            if (!result)
            {
                return BadRequest("User already exists");
            }

            return Ok(result);
        }
    }
}
