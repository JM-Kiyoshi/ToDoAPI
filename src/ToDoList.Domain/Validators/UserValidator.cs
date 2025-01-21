using FluentValidation;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x)
            .NotNull()
            .NotEmpty()
            .WithMessage("User is required.");
        
        RuleFor(user => user.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Name is required")
            
            .MinimumLength(3)
            .MaximumLength(80)
            .WithMessage("Name must be between 3 and 80 characters.");
        
        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress()
            .WithMessage(("Email is required"))
            
            .MinimumLength(11)
            .MaximumLength(180)
            .WithMessage("Email must be between 11 and 180 characters.");

        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(255)
            .WithMessage("Password must be between 6 and 16 characters.");


    }
}