using Timelive.Application.DTOs.Story;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Story;

public record UpdateStoryCommand(int Id, string Content) : ICommand<StoryResultDto>;
