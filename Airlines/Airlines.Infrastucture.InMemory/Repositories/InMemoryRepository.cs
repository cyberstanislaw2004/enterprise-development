using Airlines.Domain.Repositories;

namespace Airlines.Infrastructure.InMemory.Repositories;

public abstract class InMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly List<TEntity> _items = [];

    private int _currentId = 1;

    protected abstract int GetId(TEntity entity);

    protected abstract void SetId(TEntity entity, int id);

    protected InMemoryRepository(IEnumerable<TEntity>? seeder = null)
    {
        if (seeder != null && seeder.Any())
        {
            _items = seeder.ToList();
            _currentId = _items.Max(GetId) + 1;
        }
    }

    private int GenerateId() => 
        _currentId++;

    public int Create(TEntity entity)
    {
        SetId(entity, GenerateId());
        _items.Add(entity);
        return GetId(entity);
    }

    public List<TEntity> Read() =>
        _items.ToList();

    public TEntity? Read(int id) =>
        _items.FirstOrDefault(item => GetId(item) == id);

    public abstract TEntity? Update(int id, TEntity entity);

    public bool Delete(int id)
    {
        var existingEntity = Read(id);
        if (existingEntity == null) return false;

        _items.Remove(existingEntity);
        return true;
    }
}
