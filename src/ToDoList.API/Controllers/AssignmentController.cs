using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs;
using ToDoList.Application.Services.Interfaces;

namespace ToDoList.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssignmentController : ControllerBase
{
    private readonly IAssignmentService _assignmentService;

    public AssignmentController(IAssignmentService assignmentService)
    {
        _assignmentService = assignmentService;
    }

    [HttpPost]
    [Route("api/v1/assignment/create")]
    public async Task<ActionResult> Post([FromBody] AssignmentDTO assignmentDto)
    {
        var result = await _assignmentService.CreateAsync(assignmentDto);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}