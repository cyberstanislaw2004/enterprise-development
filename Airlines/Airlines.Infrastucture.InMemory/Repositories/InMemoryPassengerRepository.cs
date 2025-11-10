using Airlines.Domain;
using Airlines.Domain.Dataseeder;

namespace Airlines.Infrastructure.InMemory.Repositories;

/// <summary>
/// InMemory repository for managing Passenger entities
/// </summary>
public class InMemoryPassengerRepository : InMemoryRepository<Passenger>
{
    /// <summary>
    /// Initialize the repository
    /// </summary>
    public InMemoryPassengerRepository(Dataseeder? seeder) : base(seeder?.Passengers) { }

    /// <summary>
    /// Get ID of entity
    /// </summary>
    protected override int GetId(Passenger entity) => entity.Id;

    /// <summary>
    /// Set ID of entity
    /// </summary>
    protected override void SetId(Passenger entity, int id) => entity.Id = id;

    /// <summary>
    /// Update Passenger entity by ID
    /// </summary>
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