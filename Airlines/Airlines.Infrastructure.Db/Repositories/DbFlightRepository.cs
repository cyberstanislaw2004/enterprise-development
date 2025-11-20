using Airlines.Domain;
using Airlines.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Airlines.Infrastructure.Db.Repositories;

/// <summary>
/// Repository for managing Flight entities in the database
/// </summary>
public class DbFlightRepository(AppDbContext dbContext) : IRepository<Flight>
{
    /// <summary>
    /// Create a new Flight record
    /// </summary>
    public int Create(Flight entity)
    {
        dbContext.Flights.Add(entity);
        dbContext.SaveChanges();
        return entity.Id;
    }

    /// <summary>
    /// Return all Flight records
    /// </summary>
    public List<Flight> Read()
    {
        return dbContext.Flights
            .Include(x => x.AirplaneModel!)
                .ThenInclude(m => m.AirplaneFamily!)
            .AsNoTracking()
            .ToList();
    }

    /// <summary>
    /// Return Flight by ID
    /// </summary>
    public Flight? Read(int id)
    {
        return dbContext.Flights
            .Include(x => x.AirplaneModel!)
                .ThenInclude(m => m.AirplaneFamily!)
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
    }

    /// <summary>
    /// Update Flight by ID
    /// </summary>
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

    /// <summary>
    /// Delete Flight by ID
    /// </summary>
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