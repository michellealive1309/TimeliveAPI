using Microsoft.Extensions.DependencyInjection;
using Timelive.Application.Interfaces;
using Timelive.Application.Services;

namespace Timelive.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}
