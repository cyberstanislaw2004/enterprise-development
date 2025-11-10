using Airlines.Domain;
using Airlines.Domain.Dataseeder;

namespace Airlines.Infrastructure.InMemory.Repositories;

public class InMemoryTicketRepository : InMemoryRepository<Ticket>
{
    public InMemoryTicketRepository(Dataseeder? seeder) : base(seeder?.Tickets) { }

    protected override int GetId(Ticket entity) => entity.Id;
    protected override void SetId(Ticket entity, int id) => entity.Id = id;

    public override Ticket? Update(int id, Ticket entity)
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
}