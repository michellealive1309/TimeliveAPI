using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Group;

public record class DeleteGroupCommand(int GroupId) : ICommand<int>;
