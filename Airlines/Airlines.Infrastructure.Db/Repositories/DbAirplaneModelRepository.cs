using Airlines.Domain;
using Airlines.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Airlines.Infrastructure.Db.Repositories;

public class DbAirplaneModelRepository(AppDbContext dbContext) : IRepository<AirplaneModel>
{
    public int Create(AirplaneModel entity)
    {
        dbContext.AirplaneModels.Add(entity);
        dbContext.SaveChanges();
        return entity.Id;
    }

    public List<AirplaneModel> Read()
    {
        return dbContext.AirplaneModels.Include(x => x.AirplaneFamily).AsNoTracking().ToList();
    }

    public AirplaneModel? Read(int id)
    {
        return dbContext.AirplaneModels
            .Include(x => x.AirplaneFamily)
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
    }

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