using Domain.Models.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories;

public class ForumRepository : GenericRepository<Forum>, IForumRepository
{
    public ForumRepository(ForumHubDBContext _context) : base(_context)
    {
    }

    public Task<Forum> GetNested(Guid id)
    {
        return _context.Forums
            .Where(folder => folder.Id == id)
            .Include(folder => folder.Categories)
            .ThenInclude(category => category.Subforums)
            .FirstAsync();
    }
}
