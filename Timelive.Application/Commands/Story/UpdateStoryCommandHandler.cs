using Timelive.Application.DTOs.Story;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Story;

public class UpdateStoryCommandHandler : ICommandHandler<UpdateStoryCommand, StoryResultDto>
{

    public async Task<StoryResultDto> Handle(UpdateStoryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
