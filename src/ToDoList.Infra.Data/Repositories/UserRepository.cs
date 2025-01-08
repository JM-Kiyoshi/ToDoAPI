using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;
using ToDoList.Infra.Data.Context;

namespace ToDoList.Infra.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var obj = await _context.Users.AsNoTracking().Where(x => x.Email == email).FirstOrDefaultAsync();
        return obj;
    }

    public async Task<ICollection<User>> SearchByEmailAsync(string email)
    {
        var users = await _context.Users.AsNoTracking().
            Where(x => x.Email.ToLower().Contains(email.ToLower()))
            .ToListAsync();
        return users;
    }

    public async Task<ICollection<User>> SearchByNameAsync(string name)
    {
        var users = await _context.Users.AsNoTracking()
            .Where(x => x.Name.ToLower().Contains(name.ToLower()))
            .ToListAsync();
        return users;
    }

    public async Task<long> GetIdByEmailAsync(string email)
    {
        var obj = await _context.Users.AsNoTracking().Where(x => x.Email == email).FirstOrDefaultAsync();
        return obj.Id;
    }
}