using Domain.Models.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories;

public class SubForumRepository : GenericRepository<SubForum>, ISubForumRepository
{
    public SubForumRepository(ForumHubDBContext _context) : base(_context)
    {
    }

    public Task<SubForum> GetNested(Guid id)
    {
        return _context.Subforums
            .Where(s => s.Id == id)
            .Include(s => s.Topics)
            .FirstAsync();
            
    }
}
