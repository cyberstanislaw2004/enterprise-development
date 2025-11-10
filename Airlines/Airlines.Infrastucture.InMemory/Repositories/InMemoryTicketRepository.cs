using Airlines.Domain;
using Airlines.Domain.Dataseeder;

namespace Airlines.Infrastructure.InMemory.Repositories;

/// <summary>
/// InMemory repository for managing Ticket entities
/// </summary>
public class InMemoryTicketRepository : InMemoryRepository<Ticket>
{
    /// <summary>
    /// Initialize the repository
    /// </summary>
    public InMemoryTicketRepository(Dataseeder? seeder) : base(seeder?.Tickets) { }

    /// <summary>
    /// Get ID of entity
    /// </summary>
    protected override int GetId(Ticket entity) => entity.Id;

    /// <summary>
    /// Set ID of entity
    /// </summary>
    protected override void SetId(Ticket entity, int id) => entity.Id = id;

    /// <summary>
    /// Update Ticket entity by ID
    /// </summary>
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