namespace ToDoList.Application.DTOs;

public class AssignmentDTO
{
    public long Id { get; set; }
    public string Description { get; set; }
    public long UserId { get; set; }
    public bool Concluded { get; set; }
}