using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces;

public interface IAssignmentRepository : IBaseRepository<Assignment>
{
    Task<ICollection<Assignment>> SearchByUserIdAsync(long userId);
    Task<ICollection<Assignment>> SearchByConcludedStatusAsync(bool concludedStatus, long userId);
    Task<ICollection<Assignment>> SearchByDescriptionAsync(string description, long userId);
    Task<Assignment> EditConcludedStatusAsync(long assignmentId, bool concludedStatus);
    Task<Assignment> EditDescriptionAsync(long assignmentId, string description);
    Task<Assignment> EditConcludedAtAsync(long assignmentId, DateTime concludedAt);
    Task<Assignment> EditDeadlineAsync(long assignmentId, DateTime deadline);

}