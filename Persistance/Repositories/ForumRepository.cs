using Domain.Models.Entities;
using Domain.Repositories;
using System.Data.Entity;

namespace Persistance.Repositories;

public class ForumRepository : GenericRepository<Forum>, IForumRepository
{
    public Task<Forum> GetNested(Guid id)
    {
        return _context.Forums
            .Where(folder => folder.Id == id)
            .Include(folder => folder.Categories.Select(category => category.Subforums))
            .FirstAsync();
    }
}
