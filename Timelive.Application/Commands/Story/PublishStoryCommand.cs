using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Story;

public record PublishStoryCommand(int StoryId) : ICommand<int>;
