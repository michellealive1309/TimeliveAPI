using Timelive.Application.DTOs.Profile;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Queries.Profile;

public record GetProfilesQuery(IEnumerable<int> Ids, PageQuery Query) : IQuery<IEnumerable<ProfileResultDto>>;
