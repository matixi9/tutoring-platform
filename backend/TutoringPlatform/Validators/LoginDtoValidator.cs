using FluentValidation;
using TutoringPlatform.DTOs;

namespace TutoringPlatform.Validators;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Adres e-mail jest wymagany")
            .EmailAddress().WithMessage("Nieprawidłowy format adresu e-mail");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Hasło jest wymagane");
    }
}