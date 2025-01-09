using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
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
}