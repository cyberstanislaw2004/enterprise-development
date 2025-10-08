using Airlines.Application.Dto;
using Airlines.Domain;
using Airlines.Domain.Repositories;

namespace Airlines.Application.Services;

public class AirplaneFamilyService(IAirplaneFamilyRepository repository)
{
    private static AirplaneFamily MapDto(AirplaneFamilyDto entity)
    {
        return new AirplaneFamily
        {
            Id = 0,
            Name = entity.Name,
            Manufacturer = entity.Manufacturer
        };
    }

    public int CreateAirplaneFamily(AirplaneFamilyDto entity)
    {
        return repository.Create(MapDto(entity));
    }

    public List<AirplaneFamily> GetAirplaneFamilies()
    {
        return repository.Read();
    }

    public AirplaneFamily? GetAirplaneFamily(int id)
    {
        return repository.Read(id);
    }

    public AirplaneFamily? UpdateAirplaneFamily(int id, AirplaneFamilyDto entity)
    {
        return repository.Update(id, MapDto(entity));
    }

    public bool DeleteAirplaneFamily(int id)
    {
        return repository.Delete(id);
    }
}
