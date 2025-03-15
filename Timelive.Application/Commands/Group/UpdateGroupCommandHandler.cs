using Timelive.Application.DTOs.Group;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Group;

public class UpdateGroupCommandHandler : ICommandHandler<UpdateGroupCommand, GroupResultDto>
{
    public Task<GroupResultDto> Handle(UpdateGroupCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
