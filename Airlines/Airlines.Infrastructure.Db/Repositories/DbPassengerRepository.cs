using Airlines.Domain;
using Airlines.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Airlines.Infrastructure.Db.Repositories;

public class DbPassengerRepository(AppDbContext dbContext) : IRepository<Passenger>
{
    public int Create(Passenger entity)
    {
        dbContext.Passengers.Add(entity);
        dbContext.SaveChanges();
        return entity.Id;
    }

    public List<Passenger> Read()
    {
        return dbContext.Passengers
            .AsNoTracking()
            .ToList();
    }

    public Passenger? Read(int id)
    {
        return dbContext.Passengers
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
    }

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