using Airlines.Domain;
using Airlines.Domain.Dataseeder;

namespace Airlines.Infrastructure.InMemory.Repositories;

public class InMemoryPassengerRepository : InMemoryRepository<Passenger>
{
    public InMemoryPassengerRepository(Dataseeder? seeder) : base(seeder?.Passengers) { }

    protected override int GetId(Passenger entity) => entity.Id;
    protected override void SetId(Passenger entity, int id) => entity.Id = id;

    public override Passenger? Update(int id, Passenger entity)
    {
        var existingEntity = Read(id);
        if (existingEntity == null) return null;


        existingEntity.NumberOfPassport = entity.NumberOfPassport;
        existingEntity.FullName = entity.FullName;
        existingEntity.BirthDate = entity.BirthDate;
        return existingEntity;
    }
}