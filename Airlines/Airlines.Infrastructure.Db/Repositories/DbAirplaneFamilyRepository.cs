using Airlines.Domain;
using Airlines.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Airlines.Infrastructure.Db.Repositories;

/// <summary>
/// Repository for managing AirplaneFamily entities in the database
/// </summary>
public class DbAirplaneFamilyRepository(AppDbContext dbContext) : IRepository<AirplaneFamily>
{
    /// <summary>
    /// Create a new AirplaneFamily record
    /// </summary>
    public async Task<int> CreateAsync(AirplaneFamily entity)
    {
        await dbContext.AirplaneFamilies.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    /// <summary>
    /// Return all AirplaneFamily records
    /// </summary>
    public async Task<List<AirplaneFamily>> ReadAllAsync()
    {
        return await dbContext.AirplaneFamilies.AsNoTracking().ToListAsync();
    }

    /// <summary>
    /// Return AirplaneFamily by ID
    /// </summary>
    public async Task<AirplaneFamily?> ReadAsync(int id)
    {
        return await dbContext.AirplaneFamilies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    /// <summary>
    /// Update AirplaneFamily by ID
    /// </summary>
    public async Task<AirplaneFamily?> UpdateAsync(int id, AirplaneFamily entity)
    {
        var existingEntity = await dbContext.AirplaneFamilies.FindAsync(id);
        if (existingEntity == null) return null;

        existingEntity.Name = entity.Name;
        existingEntity.Manufacturer = entity.Manufacturer;
        await dbContext.SaveChangesAsync();

        return existingEntity;
    }

    /// <summary>
    /// Delete AirplaneFamily by ID
    /// </summary>
    public async Task<bool> DeleteAsync(int id)
    {
        var existingEntity = await dbContext.AirplaneFamilies.FindAsync(id);
        if (existingEntity == null) return false;

        dbContext.AirplaneFamilies.Remove(existingEntity);
        await dbContext.SaveChangesAsync();
        return true;
    }
}