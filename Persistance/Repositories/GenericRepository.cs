using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    public ForumHubDBContext _context;
    public DbSet<T> table;
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
    public async Task<T> Insert(T obj)
    {
        await table.AddAsync(obj);
        return obj;
    }
    public Task Update(T obj)
    {
        return _context.SaveChangesAsync();
    }
    public async Task<T> Delete(object id)
    {
        var existing = await table.FindAsync(id);
        if (existing == null) throw new ApplicationException();
        table.Remove(existing);
        return existing;
    }
    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
