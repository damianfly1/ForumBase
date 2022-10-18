using Domain.Models.Entities;

namespace Domain.Repositories;

public interface ISubForumRepository : IGenericRepository<SubForum>
{
    Task<SubForum> GetNested(Guid id);
}
