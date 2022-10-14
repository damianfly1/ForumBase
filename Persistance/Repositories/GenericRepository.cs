using Domain.Repositories;
using System.Data.Entity;

namespace Persistance.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    public ForumHubDBContext _context;
    public DbSet<T> table;
    public GenericRepository()
    {
        this._context = new ForumHubDBContext();
        table = _context.Set<T>();
    }
    public GenericRepository(ForumHubDBContext _context)
    {
        this._context = _context;
        table = _context.Set<T>();
    }
    public async Task<IEnumerable<T>> GetAll()
    {
       return await table.ToListAsync();
    }
    public async Task<T> GetById(object id)
    {
        return await table.FindAsync(id);
    }
    public T Insert(T obj)
    {
        return table.Add(obj);
    }
    public T Update(T obj)
    {
        T updatedEntity = table.Attach(obj);
        _context.Entry(obj).State = EntityState.Modified;
        return updatedEntity;
    }
    public T Delete(object id)
    {
        T existing = table.Find(id);
        table.Remove(existing);
        return existing;
    }
    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
