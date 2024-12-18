using ToDoList.Domain.Validators;

namespace ToDoList.Domain.Entities;

public class User
{
    public long Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public User(string name, string email, string password)
    {
        Validation(name, email, password);
    }

    public User(long id, string name, string email, string password)
    {
        DomainValidationException.When(id < 0, "UserId can't be less than zero");
        Validation(name, email, password);
    }


    private void Validation(string name, string email, string password)
    {
        DomainValidationException.When(string.IsNullOrEmpty(name), "Name is required");
        DomainValidationException.When(string.IsNullOrEmpty(email), "Email is required");
        DomainValidationException.When(string.IsNullOrEmpty(password), "Password is required");

        Name = name;
        Email = email;
        Password = password;
    }
    
    
}