using Microsoft.EntityFrameworkCore;
using ToDo.Application.Interfaces.Data;
using ToDo.Core.Entities;

namespace ToDo.Infrastructure.Data;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly ToDoDbContext _context;
    private DbSet<TEntity> _entities;

    public GenericRepository(ToDoDbContext context)
    {
        _context = context;
        _entities = context.Set<TEntity>();
    }


    public IQueryable<TEntity> GetAll() => _entities.AsQueryable();

    public async Task<TEntity?> GetById(object id) => await _entities.FindAsync(id);

    public TEntity Insert(TEntity element)
    {
        if (element == null)
            throw new ArgumentNullException(nameof(element));

        _entities.Add(element);
        return element;
    }

    public IEnumerable<TEntity> InsertRange(IEnumerable<TEntity> elements)
    {
        if (elements == null)
            throw new ArgumentNullException(nameof(elements));

        _entities.AddRange(elements);
        return elements;
    }

    public bool Delete(TEntity element)
    {
        if (element == null)
            throw new ArgumentNullException(nameof(element));

        if (!typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            return false;

        if (((ISoftDelete)element).IsDeleted == true)
            return false;

        ((ISoftDelete)element).IsDeleted = true;
        return true;
    }
}
