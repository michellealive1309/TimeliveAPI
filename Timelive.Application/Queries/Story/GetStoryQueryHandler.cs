using Timelive.Application.DTOs.Story;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Queries.Story;

public class GetStoryQueryHandler : IQueryHandler<GetStoryQuery, StoryResultDto>
{
    public async Task<StoryResultDto> Handle(GetStoryQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
