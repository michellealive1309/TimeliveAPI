using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Image;

public class UploadImageCommandHandler : ICommandHandler<UploadImageCommand, int>
{
    public Task<int> Handle(UploadImageCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
