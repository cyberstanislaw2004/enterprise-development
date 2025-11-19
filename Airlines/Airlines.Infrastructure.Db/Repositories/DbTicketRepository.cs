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
    public int Create(Ticket entity)
    {
        dbContext.Tickets.Add(entity);
        dbContext.SaveChanges();
        return entity.Id;
    }

    /// <summary>
    /// Return all Ticket records
    /// </summary>
    public List<Ticket> Read()
    {
        return dbContext.Tickets
            .Include(t => t.FlightInfo)
                .ThenInclude(f => f.AirplaneModel)
                    .ThenInclude(m => m.AirplaneFamily)
            .Include(t => t.PassengerInfo)
            .AsNoTracking()
            .ToList();
    }

    /// <summary>
    /// Return Ticket by ID
    /// </summary>
    public Ticket? Read(int id)
    {
        return dbContext.Tickets
            .Include(t => t.FlightInfo)
                .ThenInclude(f => f.AirplaneModel)
                    .ThenInclude(m => m.AirplaneFamily)
            .Include(t => t.PassengerInfo)
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
    }

    /// <summary>
    /// Update Ticket by ID
    /// </summary>
    public Ticket? Update(int id, Ticket entity)
    {
        var existingEntity = dbContext.Tickets.Find(id);
        if (existingEntity == null)
        {
            return null;
        }

        existingEntity.SeatNumber = entity.SeatNumber;
        existingEntity.HandLuggageAvailability = entity.HandLuggageAvailability;
        existingEntity.TotalBaggageWeight = entity.TotalBaggageWeight;
        existingEntity.FlightId = entity.FlightId;
        existingEntity.PassengerId = entity.PassengerId;

        dbContext.SaveChanges();
        return existingEntity;
    }

    /// <summary>
    /// Delete Ticket by ID
    /// </summary>
    public bool Delete(int id)
    {
        var existingEntity = dbContext.Tickets.Find(id);

        if (existingEntity == null)
        {
            return false;
        }

        dbContext.Tickets.Remove(existingEntity);
        dbContext.SaveChanges();

        return true;
    }
}