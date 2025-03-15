using Timelive.Application.DTOs.Profile;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Queries.Profile;

public class GetProfilesQueryHandler : IQueryHandler<GetProfilesQuery, IEnumerable<ProfileResultDto>>
{
    public Task<IEnumerable<ProfileResultDto>> Handle(GetProfilesQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
