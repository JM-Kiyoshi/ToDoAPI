using ToDoList.Application.DTOs;
using ToDoList.Application.Token;

namespace ToDoList.Application.Services.Interfaces;

public interface IUserService
{
    Task<ResultService<UserDTO>> CreateAsync(UserDTO userDto);
    Task<ResultService<UserDTO>> UpdateAsync(UserDTO userDto);
    Task<ResultService> DeleteAsync(long id);
    Task<ResultService<UserDTO>> GetByIdAsync(long id);
    Task<ResultService<ICollection<UserDTO>>> GetAllAsync();
    Task<ResultService<UserDTO>> GetByEmailAsync(string email);
    Task<ResultService<ICollection<UserDTO>>> SearchByEmailAsync(string email);
    Task<ResultService<ICollection<UserDTO>>> SearchByNameAsync(string name);
    Task<TokenDTO> Login(string email, string password);
    
    //Task<ResultService<UserDTO>> GetIdByToken(string token);

}