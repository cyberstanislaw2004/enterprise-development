using Airlines.Domain;
using Airlines.Domain.Dataseeder;

namespace Airlines.Infrastructure.InMemory.Repositories;

/// <summary>
/// InMemory repository for managing AirplaneFamily entities
/// </summary>
public class InMemoryAirplaneFamilyRepository : InMemoryRepository<AirplaneFamily>
{
    /// <summary>
    /// Initialize the repository
    /// </summary>
    public InMemoryAirplaneFamilyRepository(Dataseeder? seeder) : base(seeder?.AirplaneFamilies) { }

    /// <summary>
    /// Get ID of entity
    /// </summary>
    protected override int GetId(AirplaneFamily entity) => entity.Id;

    /// <summary>
    /// Set ID to entity
    /// </summary>
    protected override void SetId(AirplaneFamily entity, int id) => entity.Id = id;

    /// <summary>
    /// Update AirplaneFamily entity by ID
    /// </summary>
    public override AirplaneFamily? Update(int id, AirplaneFamily entity)
    {
        var existingEntity = Read(id);
        if (existingEntity == null) return null;


        existingEntity.Name = entity.Name;
        existingEntity.Manufacturer = entity.Manufacturer;
        return existingEntity;
    }
}