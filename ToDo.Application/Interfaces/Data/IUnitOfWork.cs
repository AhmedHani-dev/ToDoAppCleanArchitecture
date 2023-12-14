using ToDo.Core.Entities;

namespace ToDo.Application.Interfaces.Data;

public interface IUnitOfWork
{
    public IGenericRepository<ToDoEntry> ToDoEntriesRepository { get; }

    /// <summary>
    /// Saves all changes to the database asynchronously.
    /// </summary>
    /// <returns>Boolean true if changes were saved to the database, otherwise false.</returns>
    Task<bool> SaveChangesAsync();

    /// <summary>
    /// Disposes of the database context.
    /// </summary>
    void Dispose();
}
