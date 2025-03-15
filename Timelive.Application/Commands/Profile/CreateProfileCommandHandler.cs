using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Profile;

public class CreateProfileCommandHandler : ICommandHandler<CreateProfileCommand, int>
{
    public Task<int> Handle(CreateProfileCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
