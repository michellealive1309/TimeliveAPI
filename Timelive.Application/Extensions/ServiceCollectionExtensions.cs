using Microsoft.Extensions.DependencyInjection;
using Timelive.Application.Commands.Authentication;
using Timelive.Application.Commands.Group;
using Timelive.Application.Commands.Image;
using Timelive.Application.Commands.Profile;
using Timelive.Application.Commands.Story;
using Timelive.Application.DTOs.Account;
using Timelive.Application.DTOs.Authentication;
using Timelive.Application.DTOs.Group;
using Timelive.Application.DTOs.Profile;
using Timelive.Application.DTOs.Story;
using Timelive.Application.Interfaces;
using Timelive.Application.Queries.Account;
using Timelive.Application.Queries.Group;
using Timelive.Application.Queries.Profile;
using Timelive.Application.Queries.Story;

namespace Timelive.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<ChangePasswordCommand, bool>, ChangePasswordCommandHandler>();
        services.AddScoped<ICommandHandler<LoginCommand, LoginResultDto>, LoginCommandHandler>();
        services.AddScoped<ICommandHandler<RegisterCommand, bool>, RegisterCommandHandler>();
        services.AddScoped<ICommandHandler<CreateGroupCommand, int>, CreateGroupCommandHandler>();
        services.AddScoped<ICommandHandler<DeleteGroupCommand, int>, DeleteGroupCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateGroupCommand, GroupResultDto>, UpdateGroupCommandHandler>();
        services.AddScoped<ICommandHandler<UploadImageCommand, int>, UploadImageCommandHandler>();
        services.AddScoped<ICommandHandler<CreateProfileCommand, int>, CreateProfileCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateProfileCommand, ProfileResultDto>, UpdateProfileCommandHandler>();
        services.AddScoped<ICommandHandler<CreateStoryCommand, int>,  CreateStoryCommandHandler>();
        services.AddScoped<ICommandHandler<DeleteStoryCommand, int>, DeleteStoryCommandHandler>();
        services.AddScoped<ICommandHandler<PublishStoryCommand, int>, PublishStoryCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateStoryCommand, StoryResultDto>, UpdateStoryCommandHandler>();

        services.AddScoped<IQueryHandler<GetAccountQuery, UserResultDto>, GetAccountQueryHandler>();
        services.AddScoped<IQueryHandler<GetGroupQuery, GroupResultDto>, GetGroupQueryHandler>();
        services.AddScoped<IQueryHandler<GetGroupsQuery, IEnumerable<GroupResultDto>>, GetGroupsQueryHandler>();
        services.AddScoped<IQueryHandler<GetLikedStoriesQuery, IEnumerable<StoryResultDto>>, GetLikedStoriesQueryHandler>();
        services.AddScoped<IQueryHandler<GetProfileQuery, ProfileResultDto>, GetProfileQueryHandler>();
        services.AddScoped<IQueryHandler<GetStoriesByGroupQuery, IEnumerable<StoryResultDto>>, GetStoriesByGroupQueryHandler>();
        services.AddScoped<IQueryHandler<GetStoriesByWriterQuery, IEnumerable<StoryResultDto>>, GetStoriesByWriterQueryHandler>();
        services.AddScoped<IQueryHandler<GetStoryQuery, StoryResultDto>, GetStoryQueryHandler>();
        services.AddScoped<IQueryHandler<GetSubscribedStoriesQuery, IEnumerable<StoryResultDto>>, GetSubscribedStoriesQueryHandler>();

        return services;
    }
}
