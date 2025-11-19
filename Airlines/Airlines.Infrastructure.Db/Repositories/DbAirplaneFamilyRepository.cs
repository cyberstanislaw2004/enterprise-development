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
    public int Create(AirplaneFamily entity)
    {
        dbContext.AirplaneFamilies.Add(entity);
        dbContext.SaveChanges();
        return entity.Id;
    }

    /// <summary>
    /// Return all AirplaneFamily records
    /// </summary>
    public List<AirplaneFamily> Read()
    {
        return dbContext.AirplaneFamilies.AsNoTracking().ToList();
    }

    /// <summary>
    /// Return AirplaneFamily by ID
    /// </summary>
    public AirplaneFamily? Read(int id)
    {
        return dbContext.AirplaneFamilies.AsNoTracking().FirstOrDefault(x => x.Id == id);
    }

    /// <summary>
    /// Update AirplaneFamily by ID
    /// </summary>
    public AirplaneFamily? Update(int id, AirplaneFamily entity)
    {
        var existingEntity = dbContext.AirplaneFamilies.Find(id);
        if (existingEntity == null)
        {
            return null;
        }

        existingEntity.Name = entity.Name;
        existingEntity.Manufacturer = entity.Manufacturer;
        dbContext.SaveChanges();

        return existingEntity;
    }

    /// <summary>
    /// Delete AirplaneFamily by ID
    /// </summary>
    public bool Delete(int id)
    {
        var existingEntity = dbContext.AirplaneFamilies.Find(id);

        if (existingEntity == null)
        {
            return false;
        }

        dbContext.AirplaneFamilies.Remove(existingEntity);
        dbContext.SaveChanges();

        return true;
    }
}