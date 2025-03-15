using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Group;

public class CreateGroupCommandHandler : ICommandHandler<CreateGroupCommand, int>
{
    public Task<int> Handle(CreateGroupCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
