using Airlines.Application.Interfaces;
using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Dto;

namespace Airlines.Application.Services;

/// <summary>
/// Service for managing airplane family entities
/// </summary>
public class AirplaneFamilyService(IRepository<AirplaneFamily> repository) : IAirplaneFamilyService
{
    /// <summary>
    /// Converts create DTO to entity
    /// </summary>
    private static AirplaneFamily MapDto(AirplaneFamilyCreateDto entity)
    {
        return new AirplaneFamily
        {
            Id = 0,
            Name = entity.Name,
            Manufacturer = entity.Manufacturer
        };
    }

    /// <summary>
    /// Converts entity to read DTO
    /// </summary>
    private static AirplaneFamilyReadDto MapReadDto(AirplaneFamily entity) =>
        new(entity.Id, entity.Name, entity.Manufacturer);

    /// <summary>
    /// Create a new airplane family record
    /// </summary>
    public async Task<AirplaneFamilyReadDto> CreateAirplaneFamilyAsync(AirplaneFamilyCreateDto dto)
    {
        var entity = MapDto(dto);
        var id = await repository.CreateAsync(entity);
        var createdEntity = await repository.ReadAsync(id);

        return MapReadDto(createdEntity!);
    }

    /// <summary>
    /// Get all airplane families
    /// </summary>
    public async Task<List<AirplaneFamilyReadDto>> GetAirplaneFamiliesAsync()
    {
        var entities = await repository.ReadAllAsync();
        return entities.Select(MapReadDto).ToList();
    }

    /// <summary>
    /// Get airplane family by ID
    /// </summary>
    public async Task<AirplaneFamilyReadDto?> GetAirplaneFamilyAsync(int id)
    {
        var entity = await repository.ReadAsync(id);
        return entity == null ? null : MapReadDto(entity);
    }
    /// <summary>
    /// Update airplane family by ID
    /// </summary>
    public async Task<AirplaneFamilyReadDto?> UpdateAirplaneFamilyAsync(int id, AirplaneFamilyCreateDto dto)
    {
        var updated = await repository.UpdateAsync(id, MapDto(dto));
        return updated == null ? null : MapReadDto(updated);
    }

    /// <summary>
    /// Delete airplane family by ID
    /// </summary>
    public async Task<bool> DeleteAirplaneFamilyAsync(int id)
    {
        return await repository.DeleteAsync(id);
    }
}