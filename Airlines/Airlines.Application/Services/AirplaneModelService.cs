using Airlines.Application.Interfaces;
using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Dto;

namespace Airlines.Application.Services;

/// <summary>
/// Service for managing airplane models entities
/// </summary>
public class AirplaneModelService(IRepository<AirplaneModel> _modelRepository, IRepository<AirplaneFamily> _familyRepository) : IAirplaneModelService
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
    public async Task<AirplaneModelReadDto> CreateAirplaneModelAsync(AirplaneModelCreateDto dto)
    {
        if (!dto.FamilyId.HasValue)
            throw new ArgumentException("FamilyId is required");

        var family = await _familyRepository.ReadAsync(dto.FamilyId.Value);
        if (family == null)
            throw new ArgumentException("Invalid AirplaneFamily ID");

        var model = MapDto(dto, family);
        var id = await _modelRepository.CreateAsync(model);
        var created = await _modelRepository.ReadAsync(id);

        return MapReadDto(created!);
    }

    /// <summary>
    /// Get all airplane models
    /// </summary>
    public async Task<List<AirplaneModelReadDto>> GetAirplaneModelsAsync()
    {
        var models = await _modelRepository.ReadAllAsync();
        return models.Select(MapReadDto).ToList();
    }

    /// <summary>
    /// Get airplane model by ID
    /// </summary>
    public async Task<AirplaneModelReadDto?> GetAirplaneModelAsync(int id)
    {
        var entity = await _modelRepository.ReadAsync(id);
        return entity == null ? null : MapReadDto(entity);
    }

    /// <summary>
    /// Get airplane models by family ID
    /// </summary>
    public async Task<List<AirplaneModelReadDto>> GetAirplaneModelsByFamilyIdAsync(int familyId)
    {
        var models = await _modelRepository.ReadAllAsync();
        var filteredModels = models.Where(m => m.FamilyId == familyId).ToList();

        return filteredModels.Select(MapReadDto).ToList();
    }

    /// <summary>
    /// Update airplane model by ID
    /// </summary>
    public async Task<AirplaneModelReadDto?> UpdateAirplaneModelAsync(int id, AirplaneModelCreateDto dto)
    {
        if (!dto.FamilyId.HasValue)
            throw new ArgumentException("FamilyId is required");

        var family = await _familyRepository.ReadAsync(dto.FamilyId.Value);
        if (family == null)
            throw new ArgumentException("Invalid AirplaneFamily ID");

        var entity = MapDto(dto, family);
        var updated = await _modelRepository.UpdateAsync(id, entity);

        return updated == null ? null : MapReadDto(updated);
    }

    /// <summary>
    /// Delete airplane model by ID
    /// </summary>
    public async Task<bool> DeleteAirplaneModelAsync(int id)
    {
        return await _modelRepository.DeleteAsync(id);
    }
}