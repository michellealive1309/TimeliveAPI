using Timelive.Domain.Enums;

namespace Timelive.Domain.Entities;

public class User : Entity
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
    public string? Token { get; set; }
}
