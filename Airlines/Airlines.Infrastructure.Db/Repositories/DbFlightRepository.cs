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
    public async Task<int> CreateAsync(Flight entity)
    {
        await dbContext.Flights.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    /// <summary>
    /// Return all Flight records
    /// </summary>
    public async Task<List<Flight>> ReadAllAsync()
    {
        return await dbContext.Flights
            .Include(x => x.AirplaneModel!)
                .ThenInclude(m => m.AirplaneFamily!)
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Return Flight by ID
    /// </summary>
    public async Task<Flight?> ReadAsync(int id)
    {
        return await dbContext.Flights
            .Include(x => x.AirplaneModel!)
                .ThenInclude(m => m.AirplaneFamily!)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    /// <summary>
    /// Update Flight by ID
    /// </summary>
    public async Task<Flight?> UpdateAsync(int id, Flight entity)
    {
        var existingEntity = await dbContext.Flights.FindAsync(id);
        if (existingEntity == null) return null;

        existingEntity.FlightNumber = entity.FlightNumber;
        existingEntity.DepartureAirportCode = entity.DepartureAirportCode;
        existingEntity.DestinationAirportCode = entity.DestinationAirportCode;
        existingEntity.DepartureDate = entity.DepartureDate;
        existingEntity.ArrivalDate = entity.ArrivalDate;
        existingEntity.DepartureTime = entity.DepartureTime;
        existingEntity.Duration = entity.Duration;
        existingEntity.AirplaneModelId = entity.AirplaneModelId;

        await dbContext.SaveChangesAsync();
        return existingEntity;
    }

    /// <summary>
    /// Delete Flight by ID
    /// </summary>
    public async Task<bool> DeleteAsync(int id)
    {
        var existingEntity = await dbContext.Flights.FindAsync(id);
        if (existingEntity == null) return false;

        dbContext.Flights.Remove(existingEntity);
        await dbContext.SaveChangesAsync();
        return true;
    }
}