using Timelive.Application.DTOs.Story;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Story;

public class CreateStoryCommandHandler : ICommandHandler<CreateStoryCommand, int>
{
    public Task<int> Handle(CreateStoryCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
