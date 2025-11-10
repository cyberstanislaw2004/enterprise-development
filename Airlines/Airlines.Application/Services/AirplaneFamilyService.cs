using Airlines.Dto;
using Airlines.Domain;
using Airlines.Domain.Repositories;

namespace Airlines.Application.Services;

/// <summary>
/// Service for managing airplane family entities
/// </summary>
public class AirplaneFamilyService(IRepository<AirplaneFamily> repository)
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
    public int CreateAirplaneFamily(AirplaneFamilyCreateDto entity) =>
        repository.Create(MapDto(entity));

    /// <summary>
    /// Get all airplane families
    /// </summary>
    public List<AirplaneFamilyReadDto> GetAirplaneFamilies() =>
        repository.Read().Select(MapReadDto).ToList();

    /// <summary>
    /// Get airplane family by ID
    /// </summary>
    public AirplaneFamilyReadDto? GetAirplaneFamily(int id)
    {
        var entity = repository.Read(id);
        
        if (entity == null)
            return null;
        else
            return MapReadDto(entity);
    }

    /// <summary>
    /// Update airplane family by ID
    /// </summary>
    public AirplaneFamily? UpdateAirplaneFamily(int id, AirplaneFamilyCreateDto entity) =>
        repository.Update(id, MapDto(entity));

    /// <summary>
    /// Delete airplane family by ID
    /// </summary>
    public bool DeleteAirplaneFamily(int id) =>
        repository.Delete(id);
}