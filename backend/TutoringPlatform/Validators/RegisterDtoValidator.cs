using FluentValidation;
using TutoringPlatform.DTOs;

namespace TutoringPlatform.Validators;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Adres e-mail jest wymagany")
            .EmailAddress().WithMessage("Nieprawidłowy format adresu e-mail");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Hasło jest wymagane")
            .MinimumLength(8).WithMessage("Hasło musi mieć co najmniej 8 znaków");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nazwa użytkownika jest wymagana");

        RuleFor(x => x.Role)
            .Must(role => role.Equals("student", StringComparison.OrdinalIgnoreCase) ||
                          role.Equals("Tutor", StringComparison.OrdinalIgnoreCase))
            .WithMessage("Nieprawidłowa rola. Wybierz 'Student' lub 'Tutor'");
    }
}