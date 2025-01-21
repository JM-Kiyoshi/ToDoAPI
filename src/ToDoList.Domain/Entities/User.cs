using ToDoList.Domain.Validators;
using ToDoList.Domain.Exceptions;

namespace ToDoList.Domain.Entities;

public class User : Base
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
    
    public ICollection<Assignment> Assignments { get; set; }
    public ICollection<AssignmentList> AssignmentLists { get; set; }

    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
        CreatedAt = DateTime.Now;
        Assignments = new List<Assignment>();
        AssignmentLists = new List<AssignmentList>();
        _errors = new List<string>();
        Validate();
    }

    public void Validate()
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

    public void ChangeName(string name)
    {
        Name = name;
        Validate();
        UpdatedAt = DateTime.Now;
    }

    public void ChangeEmail(string email)
    {
        Email = email;
        Validate();
        UpdatedAt = DateTime.Now;
    }

    public void ChangePassword(string password)
    {
        Password = password;
        Validate();
        UpdatedAt = DateTime.Now;
    }

    
}