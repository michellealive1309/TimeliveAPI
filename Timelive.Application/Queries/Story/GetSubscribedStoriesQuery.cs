using Timelive.Application.DTOs.Story;
using Timelive.Application.Interfaces;
using Timelive.Application.Queries;

namespace Timelive.Application.Commands.Story;

public record GetSubscribedStoriesQuery(int ProfileId, PageQuery Query) : IQuery<IEnumerable<StoryResultDto>>;
