using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Story;

public class PublishStoryCommandHandler : ICommandHandler<PublishStoryCommand, int>
{
    public Task<int> Handle(PublishStoryCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
