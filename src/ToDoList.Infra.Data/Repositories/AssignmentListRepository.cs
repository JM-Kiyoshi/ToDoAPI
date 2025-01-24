using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Exceptions;
using ToDoList.Domain.Interfaces;
using ToDoList.Infra.Data.Context;

namespace ToDoList.Infra.Data.Repositories;

public class AssignmentListRepository : BaseRepository<AssignmentList>, IAssignmentListRepository
{
    private readonly ApplicationDbContext _context;
    public AssignmentListRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ICollection<AssignmentList>> GetAllByUserIdAsync(long userId)
    {
        var assignmentLists = await _context.AssignmentLists.AsNoTracking()
            .Where(x => x.UserId == userId).ToListAsync();
        return assignmentLists;
    }

    public async Task<AssignmentList> EditNameAsync(long id, string name)
    {
        var assignmentList = await _context.AssignmentLists.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        if (assignmentList != null)
        {
            assignmentList.ChangeName(name);
        }
        return assignmentList;
    }

    public async Task<AssignmentList> AddAsync(long id, Assignment assignment)
    {
        var assignmentList = await _context.AssignmentLists.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (assignmentList == null)
        {
            throw new DomainException("Assignment list not found");
        }
        
        assignmentList.Assignments.Add(assignment);
        
        return assignmentList;
    }

    public async Task<AssignmentList> AddAnExistingAssignmentAsync(long listId, long taskId)
    {
        var assignmentList = await _context.AssignmentLists.Include(x=> x.Assignments).FirstOrDefaultAsync(x => x.Id == listId);
        var assignment = await _context.Assignments.FirstOrDefaultAsync(x => x.Id == taskId);
        assignment.ChangeListId(assignmentList.Id);
        if (assignmentList == null || assignment == null)
        {
            throw new DomainException("Assignment list or task not found");
        }
        if (!assignmentList.Assignments.Contains(assignment))
        {
            assignmentList.Assignments.Add(assignment);
        }
        await _context.SaveChangesAsync();
        return assignmentList;
    }

    public async Task<ICollection<Assignment>> GetAllAssignmentsByListIdAsync(long listId, long userid)
    {
        var assignmentList = await _context.AssignmentLists
            .AsNoTracking()
            .Include(x => x.Assignments)
            .Where(x => x.Id == listId && x.UserId == userid).FirstOrDefaultAsync();
        if (assignmentList == null)
        {
            throw new DomainException("Assignment list not found");
        }

        return assignmentList.Assignments;
    }
}