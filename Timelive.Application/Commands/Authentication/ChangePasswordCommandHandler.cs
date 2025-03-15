using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Authentication;

public class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand, bool>
{
    public Task<bool> Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
