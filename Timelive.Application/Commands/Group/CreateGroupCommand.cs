using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Group;

public record CreateGroupCommand(string Name) : ICommand<int>;
