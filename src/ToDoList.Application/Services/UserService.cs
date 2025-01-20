using AutoMapper;
using ToDoList.Application.DTOs;
using ToDoList.Application.DTOs.Validations;
using ToDoList.Application.Services.Interfaces;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Validators;

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
        if (userDto == null)
        {
            return ResultService.Fail<UserDTO>("Object is null");
        }

        var result = new UserDTOValidator().Validate(userDto);
        if (!result.IsValid)
        {
            return ResultService.RequestError<UserDTO>("Validation Error", result);
        }
        
        var user = _mapper.Map<User>(userDto);
        var data = await _userRepository.CreateAsync(user);
        return ResultService.OK<UserDTO>(_mapper.Map<UserDTO>(data));
    }

    public async Task<ResultService<UserDTO>> UpdateAsync(UserDTO userDto)
    {
        if (userDto == null)
        {
            return ResultService.Fail<UserDTO>("Object is null");
        }
        
        var validation = new UserDTOValidator().Validate(userDto);
        if (!validation.IsValid)
        {
            return ResultService.RequestError<UserDTO>("Validation Error", validation);
        }
        
        var user = await _userRepository.GetByIdAsync(userDto.Id);
        if (user == null)
        {
            return ResultService.Fail<UserDTO>("User Not Found");
        }
        user = _mapper.Map(userDto, user);
        await _userRepository.UpdateAsync(user);
        return ResultService.OK<UserDTO>(_mapper.Map<UserDTO>(user));
    }

    public async Task<ResultService> DeleteAsync(long id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return ResultService.Fail<UserDTO>("User Not Found");
        }
        
        await _userRepository.DeleteAsync(user);
        return ResultService.OK("User Deleted");
    }

    public async Task<ResultService<UserDTO>> GetByIdAsync(long id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return ResultService.Fail<UserDTO>("User Not Found");
        }
        return ResultService.OK(_mapper.Map<UserDTO>(user));
    }

    public async Task<ResultService<ICollection<UserDTO>>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        if (users.Count == 0)
        {
            return ResultService.Fail<ICollection<UserDTO>>("Users Not Found");
        }
        return ResultService.OK(_mapper.Map<ICollection<UserDTO>>(users));
    }

    public async Task<ResultService<UserDTO>> GetByEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null)
        {
            return ResultService.Fail<UserDTO>("User Not Found");
        }
        return ResultService.OK(_mapper.Map<UserDTO>(user));
    }

    public async Task<ResultService<ICollection<UserDTO>>> SearchByEmailAsync(string email)
    {
        var users = await _userRepository.SearchByEmailAsync(email);
        if (users.Count == 0)
        {
            return ResultService.Fail<ICollection<UserDTO>>("Users Not Found");
        }
        return ResultService.OK(_mapper.Map<ICollection<UserDTO>>(users));
    }

    public async Task<ResultService<ICollection<UserDTO>>> SearchByNameAsync(string name)
    {
        var users = await _userRepository.SearchByNameAsync(name);
        if (users.Count == 0)
        {
            return ResultService.Fail<ICollection<UserDTO>>("Users Not Found");
        }
        return ResultService.OK(_mapper.Map<ICollection<UserDTO>>(users));
    }

    public async Task<ResultService<UserDTO>> EditEmailAsync(string currentEmail, string password, string newEmail)
    {
        var user = await _userRepository.EditEmailAsync(currentEmail, password, newEmail);
        return ResultService.OK(_mapper.Map<UserDTO>(user));
    }

    public async Task<ResultService<UserDTO>> EditNameAsync(string email, string password, string newName)
    {
        var user = await _userRepository.EditNameAsync(email, password, newName);
        return ResultService.OK(_mapper.Map<UserDTO>(user));
    }

    public async Task<ResultService<UserDTO>> EditPasswordAsync(string email, string password, string newPassword)
    {
        var user = await _userRepository.EditPasswordAsync(email, password, newPassword);
        return ResultService.OK(_mapper.Map<UserDTO>(user));
    }
}