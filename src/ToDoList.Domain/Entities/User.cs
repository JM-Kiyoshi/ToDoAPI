using ToDoList.Domain.Validators;
using ToDoList.Domain.Exceptions;

namespace ToDoList.Domain.Entities;

public class User : Base
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public ICollection<AssignmentList> AssignmentList { get; set; }

    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
        AssignmentList = new List<AssignmentList>();
        _errors = new List<string>();
        Validate();
    }

    private void Validate()
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
    }
}