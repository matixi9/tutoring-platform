using System.Data;
using FluentValidation;
using TutoringPlatform.DTOs;

namespace TutoringPlatform.Validators;

public class UpdateTutoringAdDtoValidator : AbstractValidator<UpdateTutoringAdDto>
{
    public UpdateTutoringAdDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(50).WithMessage("Title must not exceed 50 characters");
        
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters");
        
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is required")
            .GreaterThan(0).WithMessage("Price must be greater than 0")
            .LessThan(1000).WithMessage("Price must not exceed 1000");

        RuleFor(x => x.IsOnline)
            .NotNull().WithMessage("Online status must be set");

        RuleFor(x => x.IsAvailable)
            .NotNull().WithMessage("Availability status must be set");
    }
}