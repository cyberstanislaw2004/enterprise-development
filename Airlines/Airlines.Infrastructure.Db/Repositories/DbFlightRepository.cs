using Airlines.Domain;
using Airlines.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Airlines.Infrastructure.Db.Repositories;

public class DbFlightRepository(AppDbContext dbContext) : IRepository<Flight>
{
    public int Create(Flight entity)
    {
        dbContext.Flights.Add(entity);
        dbContext.SaveChanges();
        return entity.Id;
    }

    public List<Flight> Read()
    {
        return dbContext.Flights
            .Include(x => x.AirplaneModel)
                .ThenInclude(m => m.AirplaneFamily)
            .AsNoTracking()
            .ToList();
    }

    public Flight? Read(int id)
    {
        return dbContext.Flights
            .Include(x => x.AirplaneModel)
                .ThenInclude(m => m.AirplaneFamily)
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
    }

    public Flight? Update(int id, Flight entity)
    {
        var existingEntity = dbContext.Flights.Find(id);
        if (existingEntity == null)
        {
            return null;
        }

        existingEntity.FlightNumber = entity.FlightNumber;
        existingEntity.DepartureAirportCode = entity.DepartureAirportCode;
        existingEntity.DestinationAirportCode = entity.DestinationAirportCode;
        existingEntity.DepartureDate = entity.DepartureDate;
        existingEntity.ArrivalDate = entity.ArrivalDate;
        existingEntity.DepartureTime = entity.DepartureTime;
        existingEntity.Duration = entity.Duration;
        existingEntity.AirplaneModelId = entity.AirplaneModelId;

        dbContext.SaveChanges();
        return existingEntity;
    }

    public bool Delete(int id)
    {
        var existingEntity = dbContext.Flights.Find(id);

        if (existingEntity == null)
        {
            return false;
        }

        dbContext.Flights.Remove(existingEntity);
        dbContext.SaveChanges();

        return true;
    }
}