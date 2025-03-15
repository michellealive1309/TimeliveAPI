using Timelive.Application.DTOs.Group;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Group;

public record UpdateGroupCommand(int Id, string Name, bool IsApprovedNeed) : ICommand<GroupResultDto>;
