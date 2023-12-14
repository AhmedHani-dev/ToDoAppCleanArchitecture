using ToDo.Application.Interfaces.Data;
using ToDo.Core.Entities;

namespace ToDo.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ToDoDbContext _context;
    private bool _disposed = false;

    private IGenericRepository<ToDoEntry>? _toDoEntriesRepository;

    public UnitOfWork(ToDoDbContext context)
    {
        _context = context;
    }


    public IGenericRepository<ToDoEntry> ToDoEntriesRepository
    {
        get { return _toDoEntriesRepository ??= new GenericRepository<ToDoEntry>(_context); }
    }

    public async Task<bool> SaveChangesAsync() => (await _context.SaveChangesAsync()) > 0;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _context.Dispose();
        }

        _disposed = true;
    }
}
