using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;
using ToDoList.Infra.Data.Context;

namespace ToDoList.Infra.Data.Repositories;

public class AssignmentRepository : BaseRepository<Assignment>, IAssignmentRepository
{
    private readonly ApplicationDbContext _context;
    
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
        var assignment = await _context.Assignments.AsNoTracking()
            .Where(x => x.Id == assignmentId).FirstOrDefaultAsync();
        if (assignment != null)
        {
            assignment.ChangeConcludedStatus(concludedStatus);
        }
        return assignment;
    }

    public async Task<Assignment> EditDescriptionAsync(long assignmentId, string description)
    {
        var assignment = await _context.Assignments.AsNoTracking()
            .Where(x => x.Id == assignmentId).FirstOrDefaultAsync();
        if (assignment != null)
        {
            assignment.ChangeDescription(description);
        }
        return assignment;
    }

    public async Task<Assignment> EditConcludedAtAsync(long assignmentId, DateTime concludedAt)
    {
        var assignment = await _context.Assignments.AsNoTracking()
            .Where(x => x.Id == assignmentId).FirstOrDefaultAsync();
        if (assignment != null)
        {
            assignment.ChangeConcludedAt(concludedAt);
        }
        return assignment;
    }

    public async Task<Assignment> EditDeadlineAsync(long assignmentId, DateTime deadline)
    {
        var assignment = await _context.Assignments.AsNoTracking()
            .Where(x => x.Id == assignmentId).FirstOrDefaultAsync();
        if (assignment != null)
        {
            assignment.ChangeDeadline(deadline);
        }
        return assignment;
    }
}