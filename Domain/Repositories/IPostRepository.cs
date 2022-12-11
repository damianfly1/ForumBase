using Domain.Models.Entities;

namespace Domain.Repositories;

public interface IPostRepository : IGenericRepository<Post>
{
    Task<Post> GetWithLiked(Guid id);
}
