using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Authentication;

public record ChangePasswordCommand(string Email, string Password) : ICommand<bool>;
