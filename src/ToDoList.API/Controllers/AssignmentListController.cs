using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs;
using ToDoList.Application.Services.Interfaces;

namespace ToDoList.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssignmentListController : ControllerBase
{
    private readonly IAssignmentListService _assignmentListService;

    public AssignmentListController(IAssignmentListService assignmentListService)
    {
        _assignmentListService = assignmentListService;
    }

    [HttpPost]
    [Route("api/v1/assignment-list/create")]
    public async Task<ActionResult> Post([FromBody] AssignmentListDTO assignmentList)
    {
        var result = await _assignmentListService.CreateAsync(assignmentList);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPut]
    [Route("api/v1/assignment-list/update")]
    public async Task<ActionResult> Update([FromBody] AssignmentListDTO assignmentList)
    {
        var result = await _assignmentListService.UpdateAsync(assignmentList);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpDelete]
    [Route("api/v1/assignment-list/delete")]
    public async Task<ActionResult> Delete(long id)
    {
        var result = await _assignmentListService.DeleteAsync(id);
        if (result.IsSuccess)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet]
    [Route("api/v1/assignment-list/get-all")]
    public async Task<ActionResult> GetAll()
    {
        var result = await _assignmentListService.GetAllAsync();
        if (result.IsSuccess)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
    
    [HttpGet]
    [Route("api/v1/assignment-list/get-by-id/{id}")]
    public async Task<ActionResult> GetById(long id)
    {
        var result = await _assignmentListService.GetByIdAsync(id);
        if (result.IsSuccess)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet]
    [Route("api/v1/assignment-list/get-by-userId/{userId}")]
    public async Task<ActionResult> GetByUserId(long userId)
    {
        var result = await _assignmentListService.GetAllByUserIdAsync(userId);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        
        return BadRequest(result);
    }
}