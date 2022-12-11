using Domain.Models.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories;

public class TopicRepository : GenericRepository<Topic>, ITopicRepository
{
    public TopicRepository(ForumHubDBContext _context) : base(_context)
    {
    }

    public async Task<Topic?> GetNested(Guid id)
    {
        return await _context.Topics
            .Where(t => t.Id == id)
            .Include(t => t.Posts).ThenInclude(p => p.Author)
            .Include(t => t.Posts).ThenInclude(p => p.LikedBy)
            .FirstOrDefaultAsync();
    }
}
