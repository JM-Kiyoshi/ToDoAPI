using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs;
using ToDoList.Application.Services.Interfaces;

namespace ToDoList.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("api/v1/user/create")]
    public async Task<ActionResult> Post([FromBody] UserDTO userDto)
    {
        var result = await _userService.CreateAsync(userDto);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        
        return BadRequest(result);
    }
}