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

    public Task<ResultService<AssignmentListDTO>> CreateAsync(AssignmentListDTO assignmentListDto)
    {
        if (assignmentListDto is null)
        {
            return ResultService.Fail<AssignmentListDTO>("Object is null");
        }
    }

    public Task<ResultService<AssignmentListDTO>> UpdateAsync(AssignmentListDTO assignmentListDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResultService> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<ResultService<AssignmentListDTO>> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<ResultService<ICollection<AssignmentListDTO>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResultService<ICollection<AssignmentListDTO>>> GetAllByUserIdAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<ResultService<AssignmentListDTO>> EditNameAsync(long id, string name)
    {
        throw new NotImplementedException();
    }
}