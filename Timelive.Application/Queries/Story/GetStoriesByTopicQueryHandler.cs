using Timelive.Application.DTOs.Story;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Queries.Story;

public class GetStoriesByTopicQueryHandler : IQueryHandler<GetStoriesByTopicQuery, IEnumerable<StoryResultDto>>
{
    public Task<IEnumerable<StoryResultDto>> Handle(GetStoriesByTopicQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
