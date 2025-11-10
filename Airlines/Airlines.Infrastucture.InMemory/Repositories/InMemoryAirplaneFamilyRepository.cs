using Airlines.Domain;
using Airlines.Domain.Dataseeder;

namespace Airlines.Infrastructure.InMemory.Repositories;

public class InMemoryAirplaneFamilyRepository : InMemoryRepository<AirplaneFamily>
{
    public InMemoryAirplaneFamilyRepository(Dataseeder? seeder) : base(seeder?.AirplaneFamilies) { }

    protected override int GetId(AirplaneFamily entity) => entity.Id;
    protected override void SetId(AirplaneFamily entity, int id) => entity.Id = id;

    public override AirplaneFamily? Update(int id, AirplaneFamily entity)
    {
        var existingEntity = Read(id);
        if (existingEntity == null) return null;


        existingEntity.Name = entity.Name;
        existingEntity.Manufacturer = entity.Manufacturer;
        return existingEntity;
    }
}