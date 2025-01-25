using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ToDoList.API.Token;
using ToDoList.Application.DTOs;
using ToDoList.Application.Services.Interfaces;
using ToDoList.Application.Token;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;



namespace ToDoList.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly ITokenGenerator _tokenGenerator;

    public UserService(IUserRepository userRepository, IMapper mapper, PasswordHasher<User> passwordHasher, ITokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _tokenGenerator = tokenGenerator;
    }
    public async Task<ResultService<UserDTO>> CreateAsync(UserDTO userDto)
    {
        if (userDto == null)
        {
            return ResultService.Fail<UserDTO>("Object is null");
        }
        
        var test = await _userRepository.GetByEmailAsync(userDto.Email);
        if (test != null)
        {
            return ResultService.Fail<UserDTO>("Email already exists");
        }
        
        var user = _mapper.Map<User>(userDto);
        user.Validate();
        user.ChangePassword(_passwordHasher.HashPassword(user, userDto.Password)); 
        var data = await _userRepository.CreateAsync(user);
        return ResultService.OK<UserDTO>(_mapper.Map<UserDTO>(data));
    }

    public async Task<ResultService<UserDTO>> UpdateAsync(UserDTO userDto)
    {
        if (userDto == null)
        {
            return ResultService.Fail<UserDTO>("Object is null");
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

    public async Task<TokenDTO> Login(string email, string password)
    {
        var obj = await _userRepository.GetByEmailAsync(email);
        if (obj == null)
        {
            return new TokenDTO
            {
                AccessToken = null,
                Expiration = DateTime.MinValue
            };
        }

        var passwordValid = _passwordHasher.VerifyHashedPassword(obj, obj.Password, password);
        if (passwordValid != PasswordVerificationResult.Success)
        {
            return new TokenDTO
            {
                AccessToken = null,
                Expiration = DateTime.MinValue
            };
        }

        var token = _tokenGenerator.GenerateToken(obj);
        return new TokenDTO
        {
            AccessToken = token.AccessToken,
            Expiration = token.Expiration
        };
    }
    
}