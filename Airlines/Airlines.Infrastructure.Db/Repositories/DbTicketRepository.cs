using Airlines.Domain;
using Airlines.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Airlines.Infrastructure.Db.Repositories;

/// <summary>
/// Repository for managing Ticket entities in the database
/// </summary>
public class DbTicketRepository(AppDbContext dbContext) : IRepository<Ticket>
{
    /// <summary>
    /// Create a new Ticket record
    /// </summary>
    public async Task<int> CreateAsync(Ticket entity)
    {
        entity.Id = 0;
        await dbContext.Tickets.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    /// <summary>
    /// Return all Ticket records
    /// </summary>
    public async Task<List<Ticket>> ReadAllAsync()
    {
        return await dbContext.Tickets
            .Include(t => t.FlightInfo!)
                .ThenInclude(f => f.AirplaneModel!)
                    .ThenInclude(m => m.AirplaneFamily!)
            .Include(t => t.PassengerInfo)
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Return Ticket by ID
    /// </summary>
    public async Task<Ticket?> ReadAsync(int id)
    {
        return await dbContext.Tickets
            .Include(t => t.FlightInfo!)
                .ThenInclude(f => f.AirplaneModel!)
                    .ThenInclude(m => m.AirplaneFamily!)
            .Include(t => t.PassengerInfo)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    /// <summary>
    /// Update Ticket by ID
    /// </summary>
    public async Task<Ticket?> UpdateAsync(int id, Ticket entity)
    {
        var existingEntity = await dbContext.Tickets.FindAsync(id);
        if (existingEntity == null)
            return null;

        existingEntity.SeatNumber = entity.SeatNumber;
        existingEntity.HandLuggageAvailability = entity.HandLuggageAvailability;
        existingEntity.TotalBaggageWeight = entity.TotalBaggageWeight;
        existingEntity.FlightId = entity.FlightId;
        existingEntity.PassengerId = entity.PassengerId;

        await dbContext.SaveChangesAsync();
        return existingEntity;
    }

    /// <summary>
    /// Delete Ticket by ID
    /// </summary>
    public async Task<bool> DeleteAsync(int id)
    {
        var existingEntity = await dbContext.Tickets.FindAsync(id);
        if (existingEntity == null)
            return false;

        dbContext.Tickets.Remove(existingEntity);
        await dbContext.SaveChangesAsync();
        return true;
    }
}