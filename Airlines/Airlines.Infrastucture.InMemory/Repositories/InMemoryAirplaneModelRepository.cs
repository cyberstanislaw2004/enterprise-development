using Airlines.Domain;
using Airlines.Domain.Dataseeder;

namespace Airlines.Infrastructure.InMemory.Repositories;

/// <summary>
/// InMemory repository for managing AirplaneModel entities
/// </summary>
public class InMemoryAirplaneModelRepository : InMemoryRepository<AirplaneModel>
{
    /// <summary>
    /// Initialize the repository
    /// </summary>
    public InMemoryAirplaneModelRepository(Dataseeder? seeder) : base(seeder?.AirplaneModels) { }

    /// <summary>
    /// Get ID of entity
    /// </summary>
    protected override int GetId(AirplaneModel entity) => entity.Id;

    /// <summary>
    /// Set ID of entity
    /// </summary>
    protected override void SetId(AirplaneModel entity, int id) => entity.Id = id;

    /// <summary>
    /// Update AirplaneModel entity by ID
    /// </summary>
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