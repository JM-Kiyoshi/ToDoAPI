using AutoMapper;
using ToDoList.Application.DTOs;
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
        if (assignmentDto == null)
        {
            return ResultService.Fail<AssignmentDTO>("Object is null");
        }
        
        var assignment = _mapper.Map<Assignment>(assignmentDto);
        var data = await _assignmentRepository.CreateAsync(assignment);
        return ResultService.OK(_mapper.Map<AssignmentDTO>(data));
    }

    public async Task<ResultService<AssignmentDTO>> UpdateAsync(AssignmentDTO assignmentDto)
    {
        if (assignmentDto == null)
        {
            return ResultService.Fail<AssignmentDTO>("Object is null");
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

    public async Task<ResultService<ICollection<AssignmentDTO>>> SearchByDescriptionAsync(string description, long userId)
    {
        var assignments = await _assignmentRepository.SearchByDescriptionAsync(description, userId);
        return ResultService.OK(_mapper.Map<ICollection<AssignmentDTO>>(assignments));
    }
    
}