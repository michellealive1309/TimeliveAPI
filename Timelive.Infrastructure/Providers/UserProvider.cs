using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Timelive.Infrastructure.Interfaces;

namespace Timelive.Infrastructure.Providers;

public class UserProvider : IUserProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    private int _userId = 0;

    public UserProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetUserId()
    {
        if (_userId != 0)
        {
            return _userId;
        }

        var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => string.Equals(x.Type, ClaimTypes.NameIdentifier));
        if (int.TryParse(claim?.Value, out var userId))
        {
            _userId = userId;
            return userId;
        }

        throw new ArgumentException("Could not parse user id from claims.");
    }

    public string GetUserRold()
    {
        var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => string.Equals(x.Type, ClaimTypes.Role));
        return claim?.Value ?? throw new ArgumentException("Could not parse user role from claims.");
    }
}
