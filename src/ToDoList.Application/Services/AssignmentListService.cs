using AutoMapper;
using ToDoList.Application.DTOs;
using ToDoList.Application.Services.Interfaces;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Services;

public class AssignmentListService : IAssignmentListService
{
    private readonly IAssignmentListRepository _assignmentListRepository;
    private readonly IMapper _mapper;

    public AssignmentListService(IAssignmentListRepository assignmentListRepository, IMapper mapper)
    {
        _assignmentListRepository = assignmentListRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<AssignmentListDTO>> CreateAsync(AssignmentListDTO assignmentListDto)
    {
        if (assignmentListDto == null)
        {
            return ResultService.Fail<AssignmentListDTO>("Object is null");
        }

        var assignmentList = _mapper.Map<AssignmentList>(assignmentListDto);
        var data = await _assignmentListRepository.CreateAsync(assignmentList);
        return ResultService.OK(_mapper.Map<AssignmentListDTO>(data));
    }

    public async Task<ResultService<AssignmentListDTO>> UpdateAsync(AssignmentListDTO assignmentListDto)
    {
        if (assignmentListDto == null)
        {
            return ResultService.Fail<AssignmentListDTO>("Object is null");
        }
        
        var assignmentList = await _assignmentListRepository.GetByIdAsync(assignmentListDto.Id);
        if (assignmentList == null)
        {
            return ResultService.Fail<AssignmentListDTO>("Assignment List not found");
        }
        
        assignmentList = _mapper.Map(assignmentListDto, assignmentList);
        await _assignmentListRepository.UpdateAsync(assignmentList);
        return ResultService.OK(_mapper.Map<AssignmentListDTO>(assignmentList));
    }

    public async Task<ResultService> DeleteAsync(long id)
    {
        var assignmentList = await _assignmentListRepository.GetByIdAsync(id);
        if (assignmentList == null)
        {
            return ResultService.Fail<AssignmentListDTO>("Assignment List not found");
        }

        await _assignmentListRepository.DeleteAsync(assignmentList);
        return ResultService.OK("Assignment List deleted");
    }

    public async Task<ResultService<AssignmentListDTO>> GetByIdAsync(long id)
    {
        var assignmentList = await _assignmentListRepository.GetByIdAsync(id);
        if (assignmentList == null)
        {
            return ResultService.Fail<AssignmentListDTO>("Assignment List not found");
        }
        return ResultService.OK(_mapper.Map<AssignmentListDTO>(assignmentList));
    }

    public async Task<ResultService<ICollection<AssignmentListDTO>>> GetAllAsync()
    {
        var assignmentLists = await _assignmentListRepository.GetAllAsync();
        if (assignmentLists.Count == 0)
        {
            return ResultService.Fail<ICollection<AssignmentListDTO>>("No assignment lists found");
        }
        return ResultService.OK(_mapper.Map<ICollection<AssignmentListDTO>>(assignmentLists));
    }

    public async Task<ResultService<ICollection<AssignmentListDTO>>> GetAllByUserIdAsync(long userId)
    {
        var assignmentLists = await _assignmentListRepository.GetAllByUserIdAsync(userId);
        if (assignmentLists.Count == 0)
        {
            return ResultService.Fail<ICollection<AssignmentListDTO>>("No assignment lists found");
        }
        return ResultService.OK(_mapper.Map<ICollection<AssignmentListDTO>>(assignmentLists));
    }

    public async Task<ResultService<AssignmentListDTO>> EditNameAsync(long id, string name)
    {
        await _assignmentListRepository.EditNameAsync(id, name);
        return ResultService.OK(_mapper.Map<AssignmentListDTO>(await _assignmentListRepository.GetByIdAsync(id)));
    }
}