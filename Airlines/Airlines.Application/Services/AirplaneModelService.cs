using Airlines.Dto;
using Airlines.Domain;
using Airlines.Domain.Repositories;

namespace Airlines.Application.Services;

public class AirplaneModelService(IRepository<AirplaneModel> repository)
{
    private static AirplaneModel MapDto(AirplaneModelCreateDto entity, AirplaneFamily family)
    {
        return new AirplaneModel
        {
            Id = 0,
            ModelName = entity.ModelName,
            AirplaneFamily = family,
            RangeOfFlight = entity.RangeOfFlight,
            PassengerCapacity = entity.PassengerCapacity,
            CargoCapacity = entity.CargoCapacity
        };
    }

    private static AirplaneModelReadDto MapReadDto(AirplaneModel entity) =>
        new(
            entity.Id,
            entity.ModelName,
            new AirplaneFamilyReadDto(entity.AirplaneFamily.Id, entity.AirplaneFamily.Name, entity.AirplaneFamily.Manufacturer),
            entity.RangeOfFlight,
            entity.PassengerCapacity,
            entity.CargoCapacity
            );

    public int CreateAirplaneModel(AirplaneModelCreateDto entity, AirplaneFamily family) =>
        repository.Create(MapDto(entity, family));

    public List<AirplaneModelReadDto> GetAirplaneModels() =>
        repository.Read().Select(MapReadDto).ToList();

    public AirplaneModelReadDto? GetAirplaneModel(int id)
    {
        var entity = repository.Read(id);

        if (entity == null)
            return null;
        else
            return MapReadDto(entity);
    }

    public AirplaneModel? UpdateAirplaneModel(int id, AirplaneModelCreateDto entity, AirplaneFamily family) =>
        repository.Update(id, MapDto(entity, family));

    public bool DeleteAirplaneModel(int id) =>
        repository.Delete(id);
}
