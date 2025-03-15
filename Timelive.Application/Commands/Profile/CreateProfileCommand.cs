using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Profile;

public record CreateProfileCommand(string DisplayName) : ICommand<int>;
