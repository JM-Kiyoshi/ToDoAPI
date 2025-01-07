using ToDoList.Domain.Exceptions;
using ToDoList.Domain.Validators;

namespace ToDoList.Domain.Entities;

public class AssignmentList : Base
{
    public string Name { get; private set; }
    public long UserId { get; set; }
    public long AssignmentId { get; set; }
    public User User { get; set; }
    public Assignment Assignment { get; set; }
    public ICollection<Assignment> Assignments { get; set; }

    public AssignmentList(string name, long userId, long assignmentId)
    {
        Name = name;
        UserId = userId;
        AssignmentId = assignmentId;
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
}