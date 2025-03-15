using Microsoft.Extensions.DependencyInjection;
using Timelive.Domain.Interfaces;
using Timelive.Infrastructure.Interfaces;
using Timelive.Infrastructure.Providers;
using Timelive.Infrastructure.Repositories;

namespace Timelive.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();
        services.AddScoped<ILikeRepository, LikeRepository>();
        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<IPurchasedStoryRepository, PurchasedStoryRepository>();
        services.AddScoped<IStoryRepository, StoryRepository>();
        services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
        services.AddScoped<ITopicRepository, TopicRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    public static IServiceCollection AddProvider(this IServiceCollection services)
    {
        services.AddScoped<IUserProvider, UserProvider>();
        services.AddScoped(typeof(ICacheProvider<>), typeof(RedisCacheProvider<>));

        return services;
    }
}
