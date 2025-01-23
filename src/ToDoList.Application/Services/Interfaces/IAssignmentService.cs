using ToDoList.Application.DTOs;

namespace ToDoList.Application.Services.Interfaces;

public interface IAssignmentService
{
    Task<ResultService<AssignmentDTO>> CreateAsync(AssignmentDTO assignmentDto);
    Task<ResultService<AssignmentDTO>> UpdateAsync(AssignmentDTO assignmentDto);
    Task<ResultService> DeleteAsync(long id);
    Task<ResultService<AssignmentDTO>> GetByIdAsync(long id);
    Task<ResultService<ICollection<AssignmentDTO>>> GetAllAsync();
    Task<ResultService<ICollection<AssignmentDTO>>> SearchByUserIdAsync(long userId);
    Task<ResultService<ICollection<AssignmentDTO>>> SearchByConcludedStatusAsync(bool concludedStatus, long userId);
    Task<ResultService<ICollection<AssignmentDTO>>> SearchByDescriptionAsync(string description, long userId);
    
}