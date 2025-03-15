using Timelive.Application.DTOs.Story;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Story;

public class GetStoriesByWriterQueryHandler : IQueryHandler<GetStoriesByWriterQuery, IEnumerable<StoryResultDto>>
{
    public Task<IEnumerable<StoryResultDto>> Handle(GetStoriesByWriterQuery command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
