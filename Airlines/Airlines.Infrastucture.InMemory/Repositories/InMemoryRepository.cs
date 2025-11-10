using Airlines.Domain.Repositories;

namespace Airlines.Infrastructure.InMemory.Repositories;

/// <summary>
/// Abstract class for inMemory repository implementation
/// </summary>
public abstract class InMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly List<TEntity> _items = [];

    private int _currentId = 1;

    /// <summary>
    /// Get ID of entity
    /// </summary>
    protected abstract int GetId(TEntity entity);

    /// <summary>
    /// Set ID to entity
    /// </summary>
    protected abstract void SetId(TEntity entity, int id);

    /// <summary>
    /// Initializes the inMemory repository
    /// </summary>
    protected InMemoryRepository(IEnumerable<TEntity>? seeder = null)
    {
        if (seeder != null && seeder.Any())
        {
            _items = seeder.ToList();
            _currentId = _items.Max(GetId) + 1;
        }
    }

    /// <summary>
    /// Generate ID for new entity
    /// </summary>
    private int GenerateId() => 
        _currentId++;

    /// <summary>
    /// Adds a new entity to the repository
    /// </summary>
    public int Create(TEntity entity)
    {
        SetId(entity, GenerateId());
        _items.Add(entity);
        return GetId(entity);
    }

    /// <summary>
    /// Read all entities from the repository
    /// </summary>
    public List<TEntity> Read() =>
        _items.ToList();

    /// <summary>
    /// Read entity from the repository by ID
    /// </summary>
    public TEntity? Read(int id) =>
        _items.FirstOrDefault(item => GetId(item) == id);

    /// <summary>
    /// Update entity by ID
    /// </summary>
    public abstract TEntity? Update(int id, TEntity entity);

    /// <summary>
    /// Delete entity by ID
    /// </summary>
    public bool Delete(int id)
    {
        var existingEntity = Read(id);
        if (existingEntity == null) return false;

        _items.Remove(existingEntity);
        return true;
    }
}