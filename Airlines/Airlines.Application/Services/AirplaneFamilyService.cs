using Airlines.Dto;
using Airlines.Domain;
using Airlines.Domain.Repositories;

namespace Airlines.Application.Services;

public class AirplaneFamilyService(IRepository<AirplaneFamily> repository)
{
    private static AirplaneFamily MapDto(AirplaneFamilyCreateDto entity)
    {
        return new AirplaneFamily
        {
            Id = 0,
            Name = entity.Name,
            Manufacturer = entity.Manufacturer
        };
    }

    private static AirplaneFamilyReadDto MapReadDto(AirplaneFamily entity) =>
        new(entity.Id, entity.Name, entity.Manufacturer);

    public int CreateAirplaneFamily(AirplaneFamilyCreateDto entity) =>
        repository.Create(MapDto(entity));

    public List<AirplaneFamilyReadDto> GetAirplaneFamilies() =>
        repository.Read().Select(MapReadDto).ToList();

    public AirplaneFamilyReadDto? GetAirplaneFamily(int id)
    {
        var entity = repository.Read(id);
        
        if (entity == null)
            return null;
        else
            return MapReadDto(entity);
    }

    public AirplaneFamily? UpdateAirplaneFamily(int id, AirplaneFamilyCreateDto entity) =>
        repository.Update(id, MapDto(entity));

    public bool DeleteAirplaneFamily(int id) =>
        repository.Delete(id);
}