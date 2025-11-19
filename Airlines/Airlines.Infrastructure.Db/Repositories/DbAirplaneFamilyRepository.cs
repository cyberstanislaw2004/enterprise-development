using Airlines.Domain;
using Airlines.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Airlines.Infrastructure.Db.Repositories;

public class DbAirplaneFamilyRepository(AppDbContext dbContext) : IRepository<AirplaneFamily>
{
    public int Create(AirplaneFamily entity)
    {
        dbContext.AirplaneFamilies.Add(entity);
        dbContext.SaveChanges();
        return entity.Id;
    }

    public List<AirplaneFamily> Read()
    {
        return dbContext.AirplaneFamilies.AsNoTracking().ToList();
    }

    public AirplaneFamily? Read(int id)
    {
        return dbContext.AirplaneFamilies.AsNoTracking().FirstOrDefault(x => x.Id == id);
    }

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
