using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces;

public interface IAssignmentListRepository : IBaseRepository<AssignmentList>
{
    Task<ICollection<AssignmentList>> GetAllByUserIdAsync(long userId);
    
    Task<AssignmentList> EditNameAsync(long id, string name);
    Task<AssignmentList> AddAsync(long id, Assignment assignment);
    Task<AssignmentList> AddAnExistingAssignmentAsync(long listId, long taskId);
    Task<ICollection<Assignment>> GetAllAssignmentsByListIdAsync(long listId, long userid);

}