using Timelive.Application.DTOs.Profile;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Profile;

public class UpdateProfileCommandHandler : ICommandHandler<UpdateProfileCommand, ProfileResultDto>
{
    public Task<ProfileResultDto> Handle(UpdateProfileCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
