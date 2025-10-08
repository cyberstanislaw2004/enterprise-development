using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Infrastructure.InMemory.Dataseeder;

namespace Airlines.Infrastructure.InMemory.Repositories;

public class InMemoryTicketRepository : ITicketRepository
{
    private readonly List<Ticket> _items = [];

    public int Create(Ticket entity)
    {
        entity.Id = IdGenerator.IdNext(_items);
        _items.Add(entity);
        return entity.Id;
    }

    public List<Ticket> Read()
    {
        return _items;
    }

    public Ticket? Read(int id)
    {
        return _items.FirstOrDefault(item => item.Id == id);
    }

    public Ticket? Update(int id, Ticket entity)
    {
        var existingEntity = Read(id);
        if (existingEntity == null) return null;

        existingEntity.FlightInfo = entity.FlightInfo;
        existingEntity.PassengerInfo = entity.PassengerInfo;
        existingEntity.SeatNumber = entity.SeatNumber;
        existingEntity.HandLuggageAvailability = entity.HandLuggageAvailability;
        existingEntity.TotalBaggageWeight = entity.TotalBaggageWeight;

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