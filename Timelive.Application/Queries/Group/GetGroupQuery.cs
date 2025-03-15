using Timelive.Application.DTOs.Group;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Queries.Group;

public record GetGroupQuery(int GroupId) : IQuery<GroupResultDto>;
