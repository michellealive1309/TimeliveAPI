using Timelive.Application.DTOs.Story;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Queries.Profile;

public class GetLikedStoriesQueryHandler : IQueryHandler<GetLikedStoriesQuery, IEnumerable<StoryResultDto>>
{
    public Task<IEnumerable<StoryResultDto>> Handle(GetLikedStoriesQuery command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
