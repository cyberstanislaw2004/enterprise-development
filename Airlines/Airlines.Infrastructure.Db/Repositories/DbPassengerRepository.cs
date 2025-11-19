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
    public int Create(Passenger entity)
    {
        dbContext.Passengers.Add(entity);
        dbContext.SaveChanges();
        return entity.Id;
    }

    /// <summary>
    /// Return all Passenger records
    /// </summary>
    public List<Passenger> Read()
    {
        return dbContext.Passengers
            .AsNoTracking()
            .ToList();
    }

    /// <summary>
    /// Return Passenger by ID
    /// </summary>
    public Passenger? Read(int id)
    {
        return dbContext.Passengers
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
    }

    /// <summary>
    /// Update Passenger by ID
    /// </summary>
    public Passenger? Update(int id, Passenger entity)
    {
        var existingEntity = dbContext.Passengers.Find(id);
        if (existingEntity == null)
        {
            return null;
        }

        existingEntity.NumberOfPassport = entity.NumberOfPassport;
        existingEntity.FullName = entity.FullName;
        existingEntity.BirthDate = entity.BirthDate;
        dbContext.SaveChanges();

        return existingEntity;
    }

    /// <summary>
    /// Delete Passenger by ID
    /// </summary>
    public bool Delete(int id)
    {
        var existingEntity = dbContext.Passengers.Find(id);

        if (existingEntity == null)
        {
            return false;
        }

        dbContext.Passengers.Remove(existingEntity);
        dbContext.SaveChanges();

        return true;
    }
}