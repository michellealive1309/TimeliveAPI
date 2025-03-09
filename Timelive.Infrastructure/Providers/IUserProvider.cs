using System;

namespace Timelive.Infrastructure.Providers;

public interface IUserProvider
{
    int GetUserId();
    string GetUserRold();
}
