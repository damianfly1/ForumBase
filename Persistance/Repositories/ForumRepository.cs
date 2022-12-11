using Domain.Models.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories;

public class ForumRepository : GenericRepository<Forum>, IForumRepository
{
    public ForumRepository(ForumHubDBContext _context) : base(_context)
    {
    }

    public async Task<Forum> GetNested()
    {
        return await _context.Forums
            .Include(forum => forum.Categories)
            .ThenInclude(category => category.Subforums)
            .FirstOrDefaultAsync();
    }
}
