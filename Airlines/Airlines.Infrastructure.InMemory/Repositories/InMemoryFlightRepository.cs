using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Infrastructure.InMemory.Dataseeder;

namespace Airlines.Infrastructure.InMemory.Repositories;

public class InMemoryFlightRepository : IFlightRepository
{
    private readonly List<Flight> _items = [];

    public int Create(Flight entity)
    {
        entity.Id = IdGenerator.IdNext(_items);
        _items.Add(entity);
        return entity.Id;
    }

    public List<Flight> Read()
    {
        return _items;
    }

    public Flight? Read(int id)
    {
        return _items.FirstOrDefault(item => item.Id == id);
    }

    public Flight? Update(int id, Flight entity)
    {
        var existingEntity = Read(id);
        if (existingEntity == null) return null;

        existingEntity.FlightNumber = entity.FlightNumber;
        existingEntity.DepartureAirportCode = entity.DepartureAirportCode;
        existingEntity.DestinationAirportCode = entity.DestinationAirportCode;
        existingEntity.DepartureDate = entity.DepartureDate;
        existingEntity.ArrivalDate = entity.ArrivalDate;
        existingEntity.DepartureTime = entity.DepartureTime;
        existingEntity.Duration = entity.Duration;
        existingEntity.AirplaneModel = entity.AirplaneModel;

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