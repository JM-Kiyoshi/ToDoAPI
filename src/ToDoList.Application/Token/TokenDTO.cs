namespace ToDoList.Application.Token;

public class TokenDTO
{
    public string AccessToken { get; set; }
    public DateTime Expiration { get; set; }
}