using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmailAsync(string email);
    Task<ICollection<User>> SearchByEmailAsync(string email);
    Task<ICollection<User>> SearchByNameAsync(string name);
    Task<long> GetIdByEmailAsync(string email);
}