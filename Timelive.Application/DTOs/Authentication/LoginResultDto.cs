namespace Timelive.Application.DTOs.Authentication;

public class LoginResultDto
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}
