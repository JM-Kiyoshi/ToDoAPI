namespace ToDoList.Application.DTOs;

public class AssignmentListDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}