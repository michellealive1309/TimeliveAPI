using Timelive.Application.DTOs.Story;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Queries.Profile;

public record GetLikedStoriesQuery(int ProfileId, PageQuery PageQuery) : IQuery<IEnumerable<StoryResultDto>>;
