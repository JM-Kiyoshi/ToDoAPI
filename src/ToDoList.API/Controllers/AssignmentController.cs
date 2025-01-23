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

    [HttpPut]
    [Route("api/v1/assignment/update")]
    public async Task<ActionResult> Put([FromBody] AssignmentDTO assignmentDto)
    {
        var result = await _assignmentService.UpdateAsync(assignmentDto);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpDelete]
    [Route("api/v1/assignment/delete")]
    public async Task<ActionResult> Delete(long id)
    {
        var result = await _assignmentService.DeleteAsync(id);
        if (result.IsSuccess)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet]
    [Route("api/v1/assignment/getById{id}")]
    public async Task<ActionResult> GetById(long id)
    {
        var result = await _assignmentService.GetByIdAsync(id);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet]
    [Route("api/v1/assignment/searchByUserId/{userId}")]
    public async Task<ActionResult> SearchByUserId(long userId)
    {
        var result = await _assignmentService.SearchByUserIdAsync(userId);
        if (result.IsSuccess)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet]
    [Route("api/v1/assignment/searchByConcludedStatus/{concludedStatus}/{userId}")]
    public async Task<ActionResult> SearchByConcludedStatus(bool concludedStatus, long userId)
    {
        var result = await _assignmentService.SearchByConcludedStatusAsync(concludedStatus, userId);
        if (result.IsSuccess)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet]
    [Route("api/v1/assignment/searchByDescription/{description}/{userId}")]
    public async Task<ActionResult> SearchByDescription(string description, long userId)
    {
        var result = await _assignmentService.SearchByDescriptionAsync(description, userId);
        if (result.IsSuccess)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}