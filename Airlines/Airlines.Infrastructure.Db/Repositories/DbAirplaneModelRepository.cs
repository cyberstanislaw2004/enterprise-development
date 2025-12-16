using Airlines.Domain;
using Airlines.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Airlines.Infrastructure.Db.Repositories;

/// <summary>
/// Repository for managing AirplaneModel entities in the database
/// </summary>
public class DbAirplaneModelRepository(AppDbContext dbContext) : IRepository<AirplaneModel>
{
    /// <summary>
    /// Create a new AirplaneModel record
    /// </summary>
    public async Task<int> CreateAsync(AirplaneModel entity)
    {
        entity.Id = 0;

        await dbContext.AirplaneModels.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    /// <summary>
    /// Return all AirplaneModel records
    /// </summary>
    public async Task<List<AirplaneModel>> ReadAllAsync()
    {
        return await dbContext.AirplaneModels
            .Include(x => x.AirplaneFamily)
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Return AirplaneModel by ID
    /// </summary>
    public async Task<AirplaneModel?> ReadAsync(int id)
    {
        return await dbContext.AirplaneModels
            .Include(x => x.AirplaneFamily)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    /// <summary>
    /// Update AirplaneModel by ID
    /// </summary>
    public async Task<AirplaneModel?> UpdateAsync(int id, AirplaneModel entity)
    {
        var existingEntity = await dbContext.AirplaneModels.FindAsync(id);
        if (existingEntity == null) return null;

        existingEntity.ModelName = entity.ModelName;
        existingEntity.FamilyId = entity.FamilyId;
        existingEntity.RangeOfFlight = entity.RangeOfFlight;
        existingEntity.PassengerCapacity = entity.PassengerCapacity;
        existingEntity.CargoCapacity = entity.CargoCapacity;

        await dbContext.SaveChangesAsync();
        return existingEntity;
    }

    /// <summary>
    /// Delete AirplaneModel by ID
    /// </summary>
    public async Task<bool> DeleteAsync(int id)
    {
        var existingEntity = await dbContext.AirplaneModels.FindAsync(id);
        if (existingEntity == null) return false;

        dbContext.AirplaneModels.Remove(existingEntity);
        await dbContext.SaveChangesAsync();
        return true;
    }
}