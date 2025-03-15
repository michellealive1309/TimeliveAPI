using FluentValidation;
using Timelive.Application.Commands.Authentication;

namespace Timelive.Application.Validators;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(x => x.Username)
            .NotEmpty()
            .MinimumLength(100)
            .MaximumLength(24);
        RuleFor(x => x.Password)
            .NotEmpty()
            .MaximumLength(6)
            .MaximumLength(24);
    }
}
