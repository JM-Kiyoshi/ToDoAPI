using ToDoList.Application.DTOs;

namespace ToDoList.Application.Services.Interfaces;

public interface IAssignmentListService
{
    Task<ResultService<AssignmentListDTO>> CreateAsync(AssignmentListDTO assignmentListDto);
    Task<ResultService<AssignmentListDTO>> UpdateAsync(AssignmentListDTO assignmentListDto);
    Task<ResultService> DeleteAsync(long id);
    Task<ResultService<AssignmentListDTO>> GetByIdAsync(long id);
    Task<ResultService<ICollection<AssignmentListDTO>>> GetAllAsync();
    Task<ResultService<ICollection<AssignmentListDTO>>> GetAllByUserIdAsync(long userId);
    Task<ResultService<AssignmentListDTO>> EditNameAsync(long id, string name);
}