using System.Security.Cryptography;
using System.Text;

namespace Timelive.Application.Helpers;

public static class PasswordHelper
{
    public static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        var hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

        return hashedPassword;
    }
}
