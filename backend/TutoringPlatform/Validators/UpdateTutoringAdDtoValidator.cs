using FluentValidation;
using TutoringPlatform.DTOs;

namespace TutoringPlatform.Validators;

public class UpdateTutoringAdDtoValidator : AbstractValidator<UpdateTutoringAdDto>
{
    public UpdateTutoringAdDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Tytuł jest wymagany")
            .MaximumLength(50).WithMessage("Tytuł nie może przekraczać 50 znaków");
        
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Opis jest wymagany")
            .MaximumLength(500).WithMessage("Opis nie może przekraczać 500 znaków");
        
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Cena jest wymagana")
            .GreaterThan(0).WithMessage("Cena musi być większa niż 0")
            .LessThan(1000).WithMessage("Cena nie może przekraczać 1000zł");

        RuleFor(x => x.IsOnline)
            .NotNull().WithMessage("Status online musi być określony");

        RuleFor(x => x.IsAvailable)
            .NotNull().WithMessage("Status dostępności musi być określony");
    }
}