using Timelive.Application.DTOs.Story;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Queries.Story;

public record class GetStoryQuery(int StoryId) : IQuery<StoryResultDto>;
