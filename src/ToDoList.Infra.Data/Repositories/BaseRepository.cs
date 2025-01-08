using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;
using ToDoList.Infra.Data.Context;

namespace ToDoList.Infra.Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : Base
{
    private readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<T> CreateAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        var obj = await _context.Set<T>().AsNoTracking().Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
        if (obj != null)
        {
            _context.Set<T>().Update(obj);
            await _context.SaveChangesAsync();
        }
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        var obj = await GetByIdAsync(entity.Id);
        if (obj != null)
        {
            _context.Set<T>().Remove(obj);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(long id)
    {
        var obj = await _context.Set<T>().AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        return obj;
    }
}