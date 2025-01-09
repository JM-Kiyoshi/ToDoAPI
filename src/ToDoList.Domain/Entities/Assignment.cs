using ToDoList.Domain.Exceptions;
using ToDoList.Domain.Validators;

namespace ToDoList.Domain.Entities;

public class Assignment : Base
{
    public string Description { get; private set; }
    public long UserId { get; private set; }
    public long AssignmentListId { get; private set; }
    public bool Concluded { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public DateTime ConcludedAt { get; private set; }
    public DateTime Deadline { get; private set; }

    public User User { get; set; }
    public AssignmentList AssignmentList { get; set; }


    public Assignment(string description, long userId, long assignmentListId, bool concluded, DateTime deadline)
    {
        Description = description;
        UserId = userId;
        AssignmentListId = assignmentListId;
        CreatedAt = DateTime.Now;
        Concluded = concluded;
        Deadline = deadline;
        _errors = new List<string>();
        Validate();
    }

    private void Validate()
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
    }

    public void ChangeConcludedStatus(bool concluded)
    {
        Concluded = concluded;
        Validate();
        UpdatedAt = DateTime.Now;
    }

    public void ChangeConcludedAt(DateTime concludedAt)
    {
        ConcludedAt = concludedAt;
        Validate();
        UpdatedAt = DateTime.Now;
    }

    public void ChangeDeadline(DateTime deadline)
    {
        Deadline = deadline;
        Validate();
        UpdatedAt = DateTime.Now;
    }

    public void ChangeDescription(string description)
    {
        Description = description;
        Validate();
        UpdatedAt = DateTime.Now;
    }
}