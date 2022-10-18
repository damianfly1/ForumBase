using Domain.Models.Entities;

namespace Domain.Repositories;

public interface ITopicRepository : IGenericRepository<Topic>
{
    Task<Topic> GetNested(Guid id);
}
