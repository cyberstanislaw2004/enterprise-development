using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Dto;

namespace Airlines.Application.Services;

/// <summary>
/// Service for managing airplane models entities
/// </summary>
public class AirplaneModelService(IRepository<AirplaneModel> _modelRepository, IRepository<AirplaneFamily> _familyRepository)
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
            FamilyId = family.Id,
            AirplaneFamily = null,
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
            new AirplaneFamilyReadDto(entity.AirplaneFamily!.Id, entity.AirplaneFamily.Name, entity.AirplaneFamily.Manufacturer),
            entity.RangeOfFlight,
            entity.PassengerCapacity,
            entity.CargoCapacity
            );

    /// <summary>
    /// Create a new airplane model record
    /// </summary>
    public int CreateAirplaneModel(AirplaneModelCreateDto entity)
    {
        if (!entity.FamilyId.HasValue)
            throw new ArgumentException("FamilyId is required");

        var family = _familyRepository.Read(entity.FamilyId.Value);
        if (family == null)
            throw new ArgumentException("Invalid AirplaneFamily ID");

        var model = MapDto(entity, family);
        return _modelRepository.Create(model);
    }

    /// <summary>
    /// Get all airplane models
    /// </summary>
    public List<AirplaneModelReadDto> GetAirplaneModels() =>
        _modelRepository.Read().Select(MapReadDto).ToList();

    /// <summary>
    /// Get airplane model by ID
    /// </summary>
    public AirplaneModelReadDto? GetAirplaneModel(int id)
    {
        var entity = _modelRepository.Read(id);

        if (entity == null)
            return null;
        else
            return MapReadDto(entity);
    }

    /// <summary>
    /// Update airplane model by ID
    /// </summary>
    public AirplaneModel? UpdateAirplaneModel(int id, AirplaneModelCreateDto dto)
    {
        if (!dto.FamilyId.HasValue)
            throw new ArgumentException("FamilyId is required");

        var family = _familyRepository.Read(dto.FamilyId.Value);
        if (family == null)
            throw new ArgumentException("Invalid AirplaneFamily ID");

        var entity = MapDto(dto, family);
        return _modelRepository.Update(id, entity);
    }

    /// <summary>
    /// Delete airplane model by ID
    /// </summary>
    public bool DeleteAirplaneModel(int id) =>
        _modelRepository.Delete(id);
}