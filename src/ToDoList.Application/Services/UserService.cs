using AutoMapper;
using ToDoList.Application.DTOs;
using ToDoList.Application.Services.Interfaces;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<ResultService<UserDTO>> CreateAsync(UserDTO userDto)
    {
        if (userDto is null)
        {
            return ResultService.Fail<UserDTO>("Object is null");
        }
        
        var result = new 
    }

    public async Task<ResultService<UserDTO>> UpdateAsync(UserDTO userDto)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultService> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultService<UserDTO>> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultService<ICollection<UserDTO>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ResultService<UserDTO>> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultService<ICollection<UserDTO>>> SearchByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultService<ICollection<UserDTO>>> SearchByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultService<UserDTO>> EditEmailAsync(string currentEmail, string password, string newEmail)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultService<UserDTO>> EditNameAsync(string email, string password, string newName)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultService<UserDTO>> EditPasswordAsync(string email, string password, string newPassword)
    {
        throw new NotImplementedException();
    }
}