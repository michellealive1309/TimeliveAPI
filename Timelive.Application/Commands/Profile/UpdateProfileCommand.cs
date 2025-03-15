using Timelive.Application.DTOs.Profile;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Profile;

public record UpdateProfileCommand(int Id, string DisplayName) : ICommand<ProfileResultDto>;
