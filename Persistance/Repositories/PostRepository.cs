using Domain.Models.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(ForumHubDBContext _context) : base(_context)
    {
    }

    public async Task<Post> GetWithLiked(Guid id)
    {
        return await _context.Posts
            .Where(p => p.Id == id)
            .Include(p => p.LikedBy)
            .FirstOrDefaultAsync();
    }
}
