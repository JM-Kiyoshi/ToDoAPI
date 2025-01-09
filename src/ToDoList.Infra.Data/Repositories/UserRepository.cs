using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Exceptions;
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

    public async Task<long> GetIdByLoginAsync(string email, string password)
    {
        var obj = await _context.Users.AsNoTracking()
            .Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
        return obj.Id;
    }

    public async Task<User> EditEmailAsync(string currentEmail, string password, string newEmail)
    {
        var obj = await _context.Users.AsNoTracking()
            .Where(x => x.Email == currentEmail && x.Password == password).FirstOrDefaultAsync();
        var user = await _context.Users.AsNoTracking().Where(x => x.Email == newEmail).FirstOrDefaultAsync();
        if (user != null)
        {
            throw new DomainException("Email already exists, cannot update it.");
        }
        obj.ChangeEmail(newEmail);
        return obj;
    }

    public async Task<User> EditNameAsync(string email, string newName, string password)
    {
        var obj = await _context.Users.AsNoTracking()
            .Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
        if (obj != null)
        {
            obj.ChangeName(newName);
        }
        return obj;
    }

    public async Task<User> EditPasswordAsync(string email, string currentPassword, string newPassword)
    {
        var obj = await _context.Users.AsNoTracking()
            .Where(x => x.Email == email && x.Password == currentPassword).FirstOrDefaultAsync();
        if (obj != null)
        {
            obj.ChangePassword(newPassword);
        }
        return obj;
    }
}