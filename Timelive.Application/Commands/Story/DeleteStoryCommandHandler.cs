using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Story;

public class DeleteStoryCommandHandler : ICommandHandler<DeleteStoryCommand, int>
{
    public Task<int> Handle(DeleteStoryCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
