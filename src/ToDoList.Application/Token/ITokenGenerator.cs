using ToDoList.Domain.Entities;

namespace ToDoList.API.Token;

public interface ITokenGenerator
{
    dynamic GenerateToken(User user);
    
}