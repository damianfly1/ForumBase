namespace Domain.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(object id);
    T Insert(T obj);
    T Update(T obj);
    T Delete(object id);
    Task Save();
}
