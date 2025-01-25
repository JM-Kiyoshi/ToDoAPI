using ToDoList.Application.DTOs;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Services.Interfaces;

public interface IAssignmentListService
{
    Task<ResultService<AssignmentListDTO>> CreateAsync(string name, string token);
    Task<ResultService<AssignmentListDTO>> UpdateAsync(AssignmentListDTO assignmentListDto);
    Task<ResultService> DeleteAsync(long id);
    Task<ResultService<AssignmentListDTO>> GetByIdAsync(long id);
    Task<ResultService<ICollection<AssignmentListDTO>>> GetAllAsync();
    Task<ResultService<ICollection<AssignmentListDTO>>> GetAllByUserIdAsync(long userId);
    Task<ResultService<AssignmentListDTO>> AddAssignmentAsync(long id, AssignmentDTO assignmentDto);
    Task<ResultService<AssignmentListDTO>> AddAnExistingAssignmentAsync(long id, long assignmentId);
    Task<ResultService<ICollection<AssignmentDTO>>> GetAllAssigmentsByListIdAsync(long ListId, long userId);
}