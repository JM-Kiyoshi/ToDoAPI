using ToDoList.Domain.Validators;
using ToDoList.Domain.Exceptions;

namespace ToDoList.Domain.Entities;

public class User : Base
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public ICollection<Assignment> AssignmentList { get; private set; }

    public User(string name, string email, string password, ICollection<Assignment> assignmentList)
    {
        Name = name;
        Email = email;
        Password = password;
        AssignmentList = assignmentList;
        _errors = new List<string>();
        Validate();
    }

    public override bool Validate()
    {
        var validator = new UserValidator();
        var validation = validator.Validate(this);

        if (!validation.IsValid)
        {
            foreach (var error in validation.Errors)
            {
                _errors.Add(error.ErrorMessage);
            }

            throw new DomainException("Some field is wrong, please correct it");
        }

        return true;
    }

    public void ChangeName(string name)
    {
        Name = name;
        Validate();
    }

    public void ChangeEmail(string email)
    {
        Email = email;
        Validate();
    }

    public void ChagePassword(string password)
    {
        Password = password;
        Validate();
    }
}