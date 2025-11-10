using Airlines.Domain;
using Airlines.Domain.Dataseeder;

namespace Airlines.Infrastructure.InMemory.Repositories;

public class InMemoryAirplaneModelRepository : InMemoryRepository<AirplaneModel>
{
    public InMemoryAirplaneModelRepository(Dataseeder? seeder) : base(seeder?.AirplaneModels) { }

    protected override int GetId(AirplaneModel entity) => entity.Id;
    protected override void SetId(AirplaneModel entity, int id) => entity.Id = id;

    public override AirplaneModel? Update(int id, AirplaneModel entity)
    {
        var existingEntity = Read(id);
        if (existingEntity == null) return null;


        existingEntity.ModelName = entity.ModelName;
        existingEntity.AirplaneFamily = entity.AirplaneFamily;
        existingEntity.RangeOfFlight = entity.RangeOfFlight;
        existingEntity.PassengerCapacity = entity.PassengerCapacity;
        existingEntity.CargoCapacity = entity.CargoCapacity;
        return existingEntity;
    }
}