using Airlines.Domain;
using Airlines.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Airlines.Infrastructure.Db.Repositories;

/// <summary>
/// Repository for managing Passenger entities in the database
/// </summary>
public class DbPassengerRepository(AppDbContext dbContext) : IRepository<Passenger>
{
    /// <summary>
    /// Create a new Passenger record
    /// </summary>
    public async Task<int> CreateAsync(Passenger entity)
    {
        await dbContext.Passengers.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    /// <summary>
    /// Return all Passenger records
    /// </summary>
    public async Task<List<Passenger>> ReadAllAsync()
    {
        return await dbContext.Passengers
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Return Passenger by ID
    /// </summary>
    public async Task<Passenger?> ReadAsync(int id)
    {
        return await dbContext.Passengers
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    /// <summary>
    /// Update Passenger by ID
    /// </summary>
    public async Task<Passenger?> UpdateAsync(int id, Passenger entity)
    {
        var existingEntity = await dbContext.Passengers.FindAsync(id);
        if (existingEntity == null)
            return null;

        existingEntity.NumberOfPassport = entity.NumberOfPassport;
        existingEntity.FullName = entity.FullName;
        existingEntity.BirthDate = entity.BirthDate;

        await dbContext.SaveChangesAsync();
        return existingEntity;
    }

    /// <summary>
    /// Delete Passenger by ID
    /// </summary>
    public async Task<bool> DeleteAsync(int id)
    {
        var existingEntity = await dbContext.Passengers.FindAsync(id);
        if (existingEntity == null)
            return false;

        dbContext.Passengers.Remove(existingEntity);
        await dbContext.SaveChangesAsync();
        return true;
    }
}