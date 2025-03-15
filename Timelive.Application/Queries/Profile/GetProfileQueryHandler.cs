using Timelive.Application.DTOs.Profile;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Queries.Profile;

public class GetProfileQueryHandler : IQueryHandler<GetProfileQuery, ProfileResultDto>
{
    public Task<ProfileResultDto> Handle(GetProfileQuery command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
