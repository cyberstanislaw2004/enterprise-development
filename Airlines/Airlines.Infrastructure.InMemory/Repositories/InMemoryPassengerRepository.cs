using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Infrastructure.InMemory.Dataseeder;

namespace Airlines.Infrastructure.InMemory.Repositories;

public class InMemoryPassengerRepository : IPassengerRepository
{
    private readonly List<Passenger> _items = [];

    public int Create(Passenger entity)
    {
        entity.Id = IdGenerator.IdNext(_items);
        _items.Add(entity);
        return entity.Id;
    }

    public List<Passenger> Read()
    {
        return _items;
    }

    public Passenger? Read(int id)
    {
        return _items.FirstOrDefault(item => item.Id == id);
    }

    public Passenger? Update(int id, Passenger entity)
    {
        var existingEntity = Read(id);
        if (existingEntity == null) return null;

        existingEntity.NumberOfPassport = entity.NumberOfPassport;
        existingEntity.FullName = entity.FullName;
        existingEntity.BirthDate = entity.BirthDate;

        return existingEntity;
    }
    public bool Delete(int id)
    {
        var existingEntity = Read(id);
        if (existingEntity == null) return false;

        _items.Remove(existingEntity);
        return true;
    }
}