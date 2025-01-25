using AutoMapper;
using Microsoft.AspNetCore.Http;
using ToDoList.Application.DTOs;
using ToDoList.Application.Services.Interfaces;
using ToDoList.Application.Token;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Services;

public class AssignmentListService : IAssignmentListService
{
    private readonly IAssignmentListRepository _assignmentListRepository;
    private readonly IMapper _mapper;
    private readonly IInfoTokenUser _infoTokenUser;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AssignmentListService(IAssignmentListRepository assignmentListRepository, IMapper mapper, IInfoTokenUser infoTokenUser, IHttpContextAccessor httpContextAccessor)
    {
        _assignmentListRepository = assignmentListRepository;
        _mapper = mapper;
        _infoTokenUser = infoTokenUser;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ResultService<AssignmentListDTO>> CreateAsync(string name, string token)
    {
        if (string.IsNullOrEmpty(name))
        {
            return ResultService.Fail<AssignmentListDTO>("Assignment list name cannot be empty");
        }

        var userInfo = new InfoTokenUser(_httpContextAccessor);
        var userId = userInfo.Id;

        if (userId <= 0)
        {
            return ResultService.Fail<AssignmentListDTO>("User id is invalid");
        }

        var assignmentList = new AssignmentList(name, userId);
        var result = await _assignmentListRepository.CreateAsync(assignmentList);
        return ResultService.OK(_mapper.Map<AssignmentListDTO>(result));
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

    public async Task<ResultService<AssignmentListDTO>> AddAssignmentAsync(long id, AssignmentDTO assignmentDto)
    {
        await _assignmentListRepository.AddAsync(id, _mapper.Map<Assignment>(assignmentDto));
        return ResultService.OK(_mapper.Map<AssignmentListDTO>(assignmentDto));
    }

    public async Task<ResultService<AssignmentListDTO>> AddAnExistingAssignmentAsync(long id, long assignmentId)
    {
        await _assignmentListRepository.AddAnExistingAssignmentAsync(id, assignmentId);
        var assignmentList = await _assignmentListRepository.GetByIdAsync(id);
        return ResultService.OK(_mapper.Map<AssignmentListDTO>(assignmentList));
    }

    public async Task<ResultService<ICollection<AssignmentDTO>>> GetAllAssigmentsByListIdAsync(long listId, long userId)
    {
        var result = await _assignmentListRepository.GetAllAssignmentsByListIdAsync(listId, userId);
        return ResultService.OK(_mapper.Map<ICollection<AssignmentDTO>>(result));
    }
}