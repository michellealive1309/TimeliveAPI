using Timelive.Application.DTOs.Authentication;
using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Authentication;

public record LoginCommand(string Email, string Password) : ICommand<LoginResultDto>;
