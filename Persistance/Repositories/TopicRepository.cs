using Domain.Models.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories;

public class TopicRepository : GenericRepository<Topic>, ITopicRepository
{
    public TopicRepository(ForumHubDBContext _context) : base(_context)
    {
    }

    public Task<Topic> GetNested(Guid id)
    {
        return _context.Topics
            .Where(t => t.Id == id)
            .Include(t => t.Posts)
            .FirstAsync();
    }
}
