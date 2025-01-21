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

    [HttpPut]
    [Route("api/v1/user/update")]
    public async Task<ActionResult> Put([FromBody] UserDTO userDto)
    {
        var result = await _userService.UpdateAsync(userDto);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet]
    [Route("api/v1/user/get/{id}")]
    public async Task<ActionResult> Get(long id)
    {
        var result = await _userService.GetByIdAsync(id);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}