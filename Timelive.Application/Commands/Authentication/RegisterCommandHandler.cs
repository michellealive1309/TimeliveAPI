using Timelive.Application.Helpers;
using Timelive.Application.Interfaces;
using Timelive.Domain.Entities;
using Timelive.Domain.Enums;
using Timelive.Domain.Interfaces;

namespace Timelive.Application.Commands.Authentication;

public class RegisterCommandHandler : ICommandHandler<RegisterCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        User newUser = new()
        {
            Email = command.Email,
            Username = command.Username,
            Password = PasswordHelper.HashPassword(command.Password),
            Role = UserRole.User
        };

        if (await _userRepository.GetUserByEmailAsync(newUser.Email) != null)
        {
            return false;
        }

        await _userRepository.AddAsync(newUser);
        await _userRepository.SaveChangesAsync();

        return true;
    }
}
