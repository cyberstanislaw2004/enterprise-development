using Airlines.Domain;
using Airlines.Domain.Dataseeder;

namespace Airlines.Infrastructure.InMemory.Repositories;

public class InMemoryFlightRepository : InMemoryRepository<Flight>
{
    public InMemoryFlightRepository(Dataseeder? seeder) : base(seeder?.Flights) { }

    protected override int GetId(Flight entity) => entity.Id;
    protected override void SetId(Flight entity, int id) => entity.Id = id;

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