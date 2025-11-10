using Airlines.Domain;
using Airlines.Domain.Dataseeder;

namespace Airlines.Infrastructure.InMemory.Repositories;

/// <summary>
/// InMemory repository for managing Flight entities
/// </summary>
public class InMemoryFlightRepository : InMemoryRepository<Flight>
{
    /// <summary>
    /// Initialize the repository
    /// </summary>
    public InMemoryFlightRepository(Dataseeder? seeder) : base(seeder?.Flights) { }

    /// <summary>
    /// Get ID of entity
    /// </summary>
    protected override int GetId(Flight entity) => entity.Id;

    /// <summary>
    /// Set ID of entity
    /// </summary>
    protected override void SetId(Flight entity, int id) => entity.Id = id;

    /// <summary>
    /// Update Flight entity by ID
    /// </summary>
    public override Flight? Update(int id, Flight entity)
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
}