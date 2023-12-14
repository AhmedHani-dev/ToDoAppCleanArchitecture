namespace ToDo.Application.Interfaces.Data;

public interface IGenericRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Get all elements from a table.
    /// </summary>
    /// <returns>All the elements in the table.</returns>
    IQueryable<TEntity> GetAll();

    /// <summary>
    /// Get element by id.
    /// </summary>
    /// <param name="id">The id of the element to return.</param>
    /// <returns>The element with the same id.</returns>
    Task<TEntity?> GetById(object id);

    /// <summary>
    /// Insert element to the table.
    /// </summary>
    /// <param name="element">The element to add to the table.</param>
    TEntity Insert(TEntity element);

    /// <summary>
    /// Insert multiple elements to the table.
    /// </summary>
    /// <param name="elements">The elements to add to the table.</param>
    IEnumerable<TEntity> InsertRange(IEnumerable<TEntity> elements);

    /// <summary>
    /// Soft deletes element in table.
    /// </summary>
    /// <param name="id">The id of the element to delete.</param>
    /// <returns>Boolean True in case of a successful soft delete or false otherwise.</returns>
    bool Delete(TEntity element);
}
