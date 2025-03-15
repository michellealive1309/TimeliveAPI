using Timelive.Application.DTOs.Story;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Queries.Story;

public record GetStoriesByTopicQuery(int TopicId, PageQuery Query) : IQuery<IEnumerable<StoryResultDto>>;
