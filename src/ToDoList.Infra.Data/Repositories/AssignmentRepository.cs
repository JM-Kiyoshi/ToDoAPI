using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;
using ToDoList.Infra.Data.Context;

namespace ToDoList.Infra.Data.Repositories;

public class AssignmentRepository : BaseRepository<Assignment>, IAssignmentRepository
{
    private readonly ApplicationDbContext _context;
    private 
    public AssignmentRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ICollection<Assignment>> SearchByUserIdAsync(long userId)
    {
        var assignments = await _context.Assignments.AsNoTracking()
            .Where(x => x.UserId == userId).ToListAsync();
        return assignments;
    }

    public async Task<ICollection<Assignment>> SearchByConcludedStatusAsync(bool concludedStatus, long userId)
    {
        var assignments = await _context.Assignments.AsNoTracking()
            .Where(x => x.UserId == userId && x.Concluded == concludedStatus).ToListAsync();
        return assignments;
    }

    public async Task<ICollection<Assignment>> SearchByDescriptionAsync(string description, long userId)
    {
        var assignments = await _context.Assignments.AsNoTracking()
            .Where(x => x.UserId == userId && x.Description == description).ToListAsync();
        return assignments;
    }

    public async Task<Assignment> EditConcludedStatusAsync(long assignmentId, bool concludedStatus)
    {
        var assignment = await _context.Assignments.
    }

    public async Task<Assignment> EditDescriptionAsync(long assignmentId, string description)
    {
        throw new NotImplementedException();
    }

    public async Task<Assignment> EditConcludedAtStatusAsync(long assignmentId, DateTime concludedAt)
    {
        throw new NotImplementedException();
    }

    public async Task<Assignment> EditDeadlineAsync(long assignmentId, DateTime deadline)
    {
        throw new NotImplementedException();
    }
}