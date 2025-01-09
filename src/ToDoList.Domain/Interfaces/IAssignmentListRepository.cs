using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces;

public interface IAssignmentListRepository : IBaseRepository<AssignmentList>
{
    Task<ICollection<AssignmentList>> GetAllByUserIdAsync(long userId);
    Task<AssignmentList> EditNameAsync(long id, string name);
    
}