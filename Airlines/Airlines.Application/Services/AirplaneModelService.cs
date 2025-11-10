using Airlines.Dto;
using Airlines.Domain;
using Airlines.Domain.Repositories;

namespace Airlines.Application.Services;

/// <summary>
/// Service for managing airplane models entities
/// </summary>
public class AirplaneModelService(IRepository<AirplaneModel> repository)
{
    /// <summary>
    /// Converts create DTO to entity
    /// </summary>
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

    /// <summary>
    /// Converts entity to read DTO
    /// </summary>
    private static AirplaneModelReadDto MapReadDto(AirplaneModel entity) =>
        new(
            entity.Id,
            entity.ModelName,
            new AirplaneFamilyReadDto(entity.AirplaneFamily.Id, entity.AirplaneFamily.Name, entity.AirplaneFamily.Manufacturer),
            entity.RangeOfFlight,
            entity.PassengerCapacity,
            entity.CargoCapacity
            );

    /// <summary>
    /// Create a new airplane model record
    /// </summary>
    public int CreateAirplaneModel(AirplaneModelCreateDto entity, AirplaneFamily family) =>
        repository.Create(MapDto(entity, family));

    /// <summary>
    /// Get all airplane models
    /// </summary>
    public List<AirplaneModelReadDto> GetAirplaneModels() =>
        repository.Read().Select(MapReadDto).ToList();

    /// <summary>
    /// Get airplane model by ID
    /// </summary>
    public AirplaneModelReadDto? GetAirplaneModel(int id)
    {
        var entity = repository.Read(id);

        if (entity == null)
            return null;
        else
            return MapReadDto(entity);
    }

    /// <summary>
    /// Update airplane model by ID
    /// </summary>
    public AirplaneModel? UpdateAirplaneModel(int id, AirplaneModelCreateDto entity, AirplaneFamily family) =>
        repository.Update(id, MapDto(entity, family));

    /// <summary>
    /// Delete airplane model by ID
    /// </summary>
    public bool DeleteAirplaneModel(int id) =>
        repository.Delete(id);
}