using ToDoList.Domain.Validators;

namespace ToDoList.Domain.Entities;

public class Assignment
{
    public long Id { get; private set; }
    public string Description { get; private set; }
    public long UserId { get; private set; }
    public long AssignmentListId { get; private set; }
    public bool Concluded { get; private set; } = false;
    public DateTime ConcludedAt { get; private set; }
    public DateTime Deadline { get; private set; }

    public Assignment(string description, DateTime deadline)
    {
        Validation(description, deadline);
    }

    public Assignment(long id, string description, long userId, long assignmentListId, DateTime deadline)
    {
        DomainValidationException.When(id < 0, "Id can't be less than zero");
        DomainValidationException.When(userId < 0, "UserId can't be less than zero");
        DomainValidationException.When(assignmentListId < 0, "AssignmentListId can't be less than zero");
        Validation(description, deadline);
        Id = id;
        Description = description;
        UserId = userId;
        AssignmentListId = assignmentListId;
        Deadline = deadline;
    }


    public void Edit(string description, bool concluded, DateTime concludedAt, DateTime deadline)
    {
        Validation(description, deadline);
        Description = description;
        Concluded = concluded;
        ConcludedAt = concludedAt;
        
    }

    
    
    private void Validation(string description, DateTime deadline)
    {
        DomainValidationException.When(string.IsNullOrEmpty(description), "Description cannot be empty.");
        DomainValidationException.When(deadline < DateTime.Now, "Deadline cannot be earlier than now.");

        Description = description;
        Deadline = deadline;
    }
    
}