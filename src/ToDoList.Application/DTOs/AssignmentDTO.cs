namespace ToDoList.Application.DTOs;

public class AssignmentDTO
{
    public long Id { get; set; }
    public string Description { get; set; }
    public long UserId { get; set; }
    public long AssignmentListId { get; set; }
    public bool Concluded { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime ConcludedAt { get; set; }
    public DateTime Deadline { get; set; }
}