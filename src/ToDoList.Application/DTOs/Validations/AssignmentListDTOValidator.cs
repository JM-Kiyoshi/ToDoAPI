using FluentValidation;

namespace ToDoList.Application.DTOs.Validations;

public class AssignmentListDTOValidator : AbstractValidator<AssignmentListDTO>
{
    public AssignmentListDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("AssignmentList name cannot be empty")
            
            .MaximumLength(50)
            .WithMessage("AssignmentList name must not exceed 50 characters");
        
        RuleFor(x => x.UserId)
            .NotNull()
            .NotEmpty()
            .WithMessage("AssignmentList userId cannot be empty");
    }
}