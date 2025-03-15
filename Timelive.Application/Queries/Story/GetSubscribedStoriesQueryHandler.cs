using Timelive.Application.DTOs.Story;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Story;

public class GetSubscribedStoriesQueryHandler : IQueryHandler<GetSubscribedStoriesQuery, IEnumerable<StoryResultDto>>
{
    public Task<IEnumerable<StoryResultDto>> Handle(GetSubscribedStoriesQuery command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
