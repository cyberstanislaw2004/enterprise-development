using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Infrastructure.InMemory.Dataseeder;

namespace Airlines.Infrastructure.InMemory.Repositories;

public class InMemoryAirplaneModelRepository : IAirplaneModelRepository
{
    private readonly List<AirplaneModel> _items = [];

    public int Create(AirplaneModel entity)
    {
        entity.Id = IdGenerator.IdNext(_items);
        _items.Add(entity);
        return entity.Id;
    }

    public List<AirplaneModel> Read()
    {
        return _items;
    }

    public AirplaneModel? Read(int id)
    {
        return _items.FirstOrDefault(item => item.Id == id);
    }

    public AirplaneModel? Update(int id, AirplaneModel entity)
    {
        var existingEntity = Read(id);
        if (existingEntity == null) return null;

        existingEntity.ModelName = entity.ModelName;
        existingEntity.AirplaneFamily = entity.AirplaneFamily;
        existingEntity.RangeOfFlight = entity.RangeOfFlight;
        existingEntity.PassengerCapacity = entity.PassengerCapacity;
        existingEntity.CargoCapacity = entity.CargoCapacity;

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