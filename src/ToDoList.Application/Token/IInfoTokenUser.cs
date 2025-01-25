namespace ToDoList.Application.Token;

public interface IInfoTokenUser
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}