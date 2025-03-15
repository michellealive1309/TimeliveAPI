using Timelive.Application.DTOs.Group;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Queries.Group;

public class GetGroupsQueryHandler : IQueryHandler<GetGroupsQuery, IEnumerable<GroupResultDto>>
{
    public Task<IEnumerable<GroupResultDto>> Handle(GetGroupsQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
