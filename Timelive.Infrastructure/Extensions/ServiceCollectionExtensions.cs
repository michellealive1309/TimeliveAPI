using Microsoft.Extensions.DependencyInjection;
using Timelive.Domain.Interfaces;
using Timelive.Infrastructure.Providers;
using Timelive.Infrastructure.Repositories;

namespace Timelive.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    public static IServiceCollection AddProvider(this IServiceCollection services)
    {
        services.AddScoped<IUserProvider, UserProvider>();

        return services;
    }
}
