using FluentValidation;
using FluentValidation.Validators;
using TutoringPlatform.DTOs;

namespace TutoringPlatform.Validators;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long");
        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required");

        RuleFor(x => x.Role)
            .Must(role => role.Equals("student", StringComparison.OrdinalIgnoreCase) ||
                          role.Equals("Tutor", StringComparison.OrdinalIgnoreCase))
            .WithMessage("Invalid role. Choose either 'Student' or 'Tutor'");
    }
}