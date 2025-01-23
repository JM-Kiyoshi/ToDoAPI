using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces;

public interface IAssignmentRepository : IBaseRepository<Assignment>
{
    Task<ICollection<Assignment>> SearchByUserIdAsync(long userId);
    Task<ICollection<Assignment>> SearchByConcludedStatusAsync(bool concludedStatus, long userId);
    Task<ICollection<Assignment>> SearchByDescriptionAsync(string description, long userId);
    
}