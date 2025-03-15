using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Group;

public class DeleteGroupCommandHandler : ICommandHandler<DeleteGroupCommand, int>
{
    public Task<int> Handle(DeleteGroupCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
