using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Infrastructure.InMemory.Dataseeder;

namespace Airlines.Infrastructure.InMemory.Repositories;

public class InMemoryAirplaneFamilyRepository : IAirplaneFamilyRepository
{
    private readonly List<AirplaneFamily> _items = [];

    private int _currentId = 1;

    public InMemoryAirplaneFamilyRepository(InMemoryRepositoryDataseeder? seeder)
    {
        if (seeder == null) return;

        _items = seeder.AirplaneFamilies;
    }
}
