namespace Airlines.Domain.Repositories;

/// <summary>
/// Generic repository interface for CRUD operations
/// </summary>
public interface IRepository<TEntity>
{
    /// <summary>
    /// Create a new entity
    /// </summary>
    public int Create(TEntity entity);

    /// <summary>
    /// Return all entities from repository
    /// </summary>
    public List<TEntity> Read();

    /// <summary>
    /// Return entity by ID
    /// </summary>
    public TEntity? Read(int id);

    /// <summary>
    /// Update entity by ID
    /// </summary>
    public TEntity? Update(int id, TEntity entity);

    /// <summary>
    /// Delete entity by ID
    /// </summary>
    public bool Delete(int id);
}