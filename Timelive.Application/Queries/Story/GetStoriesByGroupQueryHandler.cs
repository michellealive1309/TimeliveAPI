using Timelive.Application.DTOs.Story;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Queries.Story;

public class GetStoriesByGroupQueryHandler : IQueryHandler<GetStoriesByGroupQuery, IEnumerable<StoryResultDto>>
{
    public Task<IEnumerable<StoryResultDto>> Handle(GetStoriesByGroupQuery command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
