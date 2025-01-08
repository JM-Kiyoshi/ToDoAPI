using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces;

public interface IBaseRepository<T> where T : Base
{
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(long id);
}