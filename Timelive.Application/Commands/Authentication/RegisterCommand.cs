using Timelive.Application.Interfaces;

namespace Timelive.Application.Commands.Authentication;

public record RegisterCommand(string Email, string Username, string Password) : ICommand<bool>;
