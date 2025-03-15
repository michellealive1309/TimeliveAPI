using Timelive.Application.DTOs.Story;
using Timelive.Application.Interfaces;
using Timelive.Application.Queries;

namespace Timelive.Application.Commands.Story;

public record class GetStoriesByWriterQuery(int WriterId, PageQuery Query) : IQuery<IEnumerable<StoryResultDto>>
{

}
