using Timelive.Application.DTOs.Group;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Queries.Group;

public record GetGroupsQuery(IEnumerable<int> Ids, PageQuery Query) : IQuery<IEnumerable<GroupResultDto>>;
