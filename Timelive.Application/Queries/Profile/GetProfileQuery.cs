using Timelive.Application.DTOs.Profile;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Queries.Profile;

public record GetProfileQuery(int ProfileId) : IQuery<ProfileResultDto>;
