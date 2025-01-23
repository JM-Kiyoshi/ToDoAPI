using FluentValidation;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Validators;

public class AssignmentValidator : AbstractValidator<Assignment>
{
    public AssignmentValidator()
    {
        RuleFor(x => x)
            .NotNull()
            .NotEmpty()
            .WithMessage("Assignment is required");
        
        RuleFor(x => x.Description)
            .NotNull()
            .NotEmpty()
            .WithMessage("Description is required")
            
            .MinimumLength(1)
            .WithMessage("Description must have at least one character")
            .MaximumLength(500)
            .WithMessage("Description must not exceed 500 characters");
        
        RuleFor(x => x.UserId)
            .NotNull()
            .NotEmpty()
            .WithMessage("UserId is required");

        RuleFor(x => x.Deadline)
            .GreaterThan(x => x.CreatedAt)
            .WithMessage("Deadline must be greater than created date");
    }
}