using Timelive.Application.DTOs.Story;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Queries.Story;

public record GetStoriesByGroupQuery(int GroupId, PageQuery Query) : IQuery<IEnumerable<StoryResultDto>>
{

}
