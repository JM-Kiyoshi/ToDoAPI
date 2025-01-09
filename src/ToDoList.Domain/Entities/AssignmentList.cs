using ToDoList.Domain.Exceptions;
using ToDoList.Domain.Validators;

namespace ToDoList.Domain.Entities;

public class AssignmentList : Base
{
    public string Name { get; private set; }
    public long UserId { get; set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
    public User User { get; set; }
    public Assignment Assignment { get; set; }
    public ICollection<Assignment> Assignments { get; set; }

    public AssignmentList(string name, long userId)
    {
        Name = name;
        UserId = userId;
        CreatedAt = DateTime.Now;
        Assignments = new List<Assignment>();
        _errors = new List<string>();
        Validate();
    }
    
    private void Validate()
    {
        var validator = new AssignmentListValidator();
        var validation = validator.Validate(this);
        if (!validation.IsValid)
        {
            foreach (var error in validation.Errors)
            {
                _errors.Add(error.PropertyName);
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
}