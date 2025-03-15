using Timelive.Application.DTOs.Story;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Story;

public record CreateStoryCommand(string Title) : ICommand<int>;
