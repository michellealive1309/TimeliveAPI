using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Story;

public record DeleteStoryCommand(int StoryId) : ICommand<int>
{

}
