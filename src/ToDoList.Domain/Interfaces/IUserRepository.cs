using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmailAsync(string email);
    Task<ICollection<User>> SearchByEmailAsync(string email);
    Task<ICollection<User>> SearchByNameAsync(string name);
    Task<long> GetIdByLoginAsync(string email, string password);
    Task<User> EditEmailAsync(string currentEmail, string password, string newEmail);
    Task<User> EditNameAsync(string email, string password, string newName);
    Task<User> EditPasswordAsync(string email, string currentPassword, string newPassword);
}