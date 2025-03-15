using Timelive.Application.DTOs.Group;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Queries.Group;

public class GetGroupQueryHandler : IQueryHandler<GetGroupQuery, GroupResultDto>
{
    public Task<GroupResultDto> Handle(GetGroupQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
