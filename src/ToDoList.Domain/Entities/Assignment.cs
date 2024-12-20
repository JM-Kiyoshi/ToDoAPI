using ToDoList.Domain.Exceptions;
using ToDoList.Domain.Validators;

namespace ToDoList.Domain.Entities;

public class Assignment : Base
{
    public string Description { get; private set; }
    public long UserId { get; private set; }
    public long AssignmentListId { get; private set; }
    public bool Concluded { get; private set; } = false;
    public DateTime ConcludedAt { get; private set; }
    public DateTime Deadline { get; private set; }


    public Assignment(string description, long userId, long assignmentListId, bool concluded, DateTime concludedAt, DateTime deadline)
    {
        Description = description;
        UserId = userId;
        AssignmentListId = assignmentListId;
        Concluded = concluded;
        ConcludedAt = concludedAt;
        Deadline = deadline;
        _errors = new List<string>();
        Validate();
    }

    public override bool Validate()
    {
        var validator = new AssignmentValidator();
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
}