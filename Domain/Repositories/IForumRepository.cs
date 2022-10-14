using Domain.Models.Entities;

namespace Domain.Repositories;

public interface IForumRepository : IGenericRepository<Forum>
{
    Task<Forum> GetNested(Guid id);
}
