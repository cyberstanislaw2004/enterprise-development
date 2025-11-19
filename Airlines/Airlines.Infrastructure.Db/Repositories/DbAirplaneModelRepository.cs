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
    public int Create(AirplaneModel entity)
    {
        dbContext.AirplaneModels.Add(entity);
        dbContext.SaveChanges();
        return entity.Id;
    }

    /// <summary>
    /// Return all AirplaneModel records
    /// </summary>
    public List<AirplaneModel> Read()
    {
        return dbContext.AirplaneModels.Include(x => x.AirplaneFamily).AsNoTracking().ToList();
    }

    /// <summary>
    /// Return AirplaneModel by ID
    /// </summary>
    public AirplaneModel? Read(int id)
    {
        return dbContext.AirplaneModels
            .Include(x => x.AirplaneFamily)
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
    }

    /// <summary>
    /// Update AirplaneModel by ID
    /// </summary>
    public AirplaneModel? Update(int id, AirplaneModel entity)
    {
        var existingEntity = dbContext.AirplaneModels.Find(id);

        if (existingEntity == null)
        {
            return null;
        }

        existingEntity.ModelName = entity.ModelName;
        existingEntity.FamilyId = entity.FamilyId;
        existingEntity.RangeOfFlight = entity.RangeOfFlight;
        existingEntity.PassengerCapacity = entity.PassengerCapacity;
        existingEntity.CargoCapacity = entity.CargoCapacity;
        dbContext.SaveChanges();

        return existingEntity;
    }

    /// <summary>
    /// Delete AirplaneModel by ID
    /// </summary>
    public bool Delete(int id)
    {
        var existingEntity = dbContext.AirplaneModels.Find(id);

        if (existingEntity == null)
        {
            return false;
        }

        dbContext.AirplaneModels.Remove(existingEntity);
        dbContext.SaveChanges();

        return true;
    }
}