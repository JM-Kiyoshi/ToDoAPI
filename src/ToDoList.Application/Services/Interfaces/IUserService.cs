using ToDoList.Application.DTOs;

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
}