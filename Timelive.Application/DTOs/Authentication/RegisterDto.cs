using System;

namespace Timelive.Application.DTOs.Authentication;

public class RegisterDto
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
