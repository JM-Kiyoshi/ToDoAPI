using AutoMapper;
using ToDoList.Application.DTOs;
using ToDoList.Application.DTOs.Validations;
using ToDoList.Application.Services.Interfaces;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Services;

public class AssignmentService : IAssignmentService
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IMapper _mapper;

    public AssignmentService(IAssignmentRepository assignmentRepository, IMapper mapper)
    {
        _assignmentRepository = assignmentRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<AssignmentDTO>> CreateAsync(AssignmentDTO assignmentDto)
    {
        if (assignmentDto is null)
        {
            return ResultService.Fail<AssignmentDTO>("Object is null");
        }
        var result = new AssignmentDTOValidator().Validate(assignmentDto);
        if (!result.IsValid)
        {
            return ResultService.RequestError<AssignmentDTO>("Validation Error", result);
        }
        
        var assignment = _mapper.Map<Assignment>(assignmentDto);
        var data = await _assignmentRepository.CreateAsync(assignment);
        return ResultService.OK(_mapper.Map<AssignmentDTO>(data));
    }

    public async Task<ResultService<AssignmentDTO>> UpdateAsync(AssignmentDTO assignmentDto)
    {
        if (assignmentDto is null)
        {
            return ResultService.Fail<AssignmentDTO>("Object is null");
        }
        
        var result = new AssignmentDTOValidator().Validate(assignmentDto);
        if (!result.IsValid)
        {
            return ResultService.RequestError<AssignmentDTO>("Validation Error", result);
        }
        var assignment = await _assignmentRepository.GetByIdAsync(assignmentDto.Id);
        if (assignment == null)
        {
            return ResultService.Fail<AssignmentDTO>("Assignment not found");
        }
        assignment = _mapper.Map(assignmentDto, assignment);
        await _assignmentRepository.UpdateAsync(assignment);
        return ResultService.OK(_mapper.Map<AssignmentDTO>(assignment));
    }

    public async Task<ResultService> DeleteAsync(long id)
    {
        var assignment = await _assignmentRepository.GetByIdAsync(id);
        if (assignment == null)
        {
            return ResultService.Fail<AssignmentDTO>("Assignment not found");
        }
        await _assignmentRepository.DeleteAsync(assignment);
        return ResultService.OK("Assignment deleted");
    }

    public async Task<ResultService<AssignmentDTO>> GetByIdAsync(long id)
    {
        var assignment = await _assignmentRepository.GetByIdAsync(id);
        if (assignment == null)
        {
            return ResultService.Fail<AssignmentDTO>("Assignment not found");
        }
        return ResultService.OK(_mapper.Map<AssignmentDTO>(assignment));
    }

    public async Task<ResultService<ICollection<AssignmentDTO>>> GetAllAsync()
    {
        var assignments = await _assignmentRepository.GetAllAsync();
        return ResultService.OK(_mapper.Map<ICollection<AssignmentDTO>>(assignments));
    }

    public async Task<ResultService<ICollection<AssignmentDTO>>> SearchByUserIdAsync(long userId)
    {
        var assignments = await _assignmentRepository.SearchByUserIdAsync(userId);
        return ResultService.OK(_mapper.Map<ICollection<AssignmentDTO>>(assignments));
    }

    public async Task<ResultService<ICollection<AssignmentDTO>>> SearchByConcludedStatusAsync(bool concludedStatus, long userId)
    {
        var assignments = await _assignmentRepository.SearchByConcludedStatusAsync(concludedStatus, userId);
        return ResultService.OK(_mapper.Map<ICollection<AssignmentDTO>>(assignments));
    }

    public async Task<ResultService<AssignmentDTO>> SearchByDescriptionAsync(string description, long userId)
    {
        var assignments = await _assignmentRepository.SearchByDescriptionAsync(description, userId);
        return ResultService.OK(_mapper.Map<AssignmentDTO>(assignments));
    }

    public async Task<ResultService<AssignmentDTO>> EditConcludedStatusAsync(long assignmentId, bool concludedStatus)
    {
        var result = await _assignmentRepository.EditConcludedStatusAsync(assignmentId, concludedStatus);
        return ResultService.OK(_mapper.Map<AssignmentDTO>(result));
    }

    public async Task<ResultService<AssignmentDTO>> EditDescriptionAsync(long assignmentId, string description)
    {
        var result = await _assignmentRepository.EditDescriptionAsync(assignmentId, description);
        return ResultService.OK(_mapper.Map<AssignmentDTO>(result));
    }

    public async Task<ResultService<AssignmentDTO>> EditConcludedAtAsync(long assignmentId, DateTime concludedAt)
    {
        var result = await _assignmentRepository.EditConcludedAtAsync(assignmentId, concludedAt);
        return ResultService.OK(_mapper.Map<AssignmentDTO>(result));
    }

    public async Task<ResultService<AssignmentDTO>> EditDeadlineAsync(long assignmentId, DateTime deadline)
    {
        var result = await _assignmentRepository.EditDeadlineAsync(assignmentId, deadline);
        return ResultService.OK(_mapper.Map<AssignmentDTO>(result));
    }
}