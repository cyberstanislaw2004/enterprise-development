using Airlines.Application.Dto;
using Airlines.Domain;
using Airlines.Domain.Repositories;

namespace Airlines.Application.Services;

public class AirplaneModelService(IAirplaneModelRepository repository)
{
    private static AirplaneModel MapDto(AirplaneModelDto entity, AirplaneFamily family)
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

    public int CreateAirplaneModel(AirplaneModelDto entity, AirplaneFamily family)
    {
        return repository.Create(MapDto(entity, family));
    }

    public List<AirplaneModel> GetAirplaneModels()
    {
        return repository.Read();
    }

    public AirplaneModel? GetAirplaneModel(int id)
    {
        return repository.Read(id);
    }

    public AirplaneModel? UpdateAirplaneModel(int id, AirplaneModelDto entity, AirplaneFamily family)
    {
        return repository.Update(id, MapDto(entity, family));
    }

    public bool DeleteAirplaneModel(int id)
    {
        return repository.Delete(id);
    }
}
