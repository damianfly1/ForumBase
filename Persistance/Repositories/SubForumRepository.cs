using Domain.Models.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories;

public class SubForumRepository : GenericRepository<SubForum>, ISubForumRepository
{
    public SubForumRepository(ForumHubDBContext _context) : base(_context)
    {
    }

    public async Task<SubForum> GetNested(Guid id)
    {
        return await _context.Subforums
            .Where(s => s.Id == id)
            .Include(s => s.Topics).ThenInclude(t=> t.Author)
            .Include(s => s.Topics).ThenInclude(t => t.Posts)
            .FirstOrDefaultAsync();
    }
}
