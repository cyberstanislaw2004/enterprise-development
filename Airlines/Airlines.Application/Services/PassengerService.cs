using Airlines.Application.Interfaces;
using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Dto;

namespace Airlines.Application.Services;

/// <summary>
/// Service for managing passengers entities
/// </summary>
public class PassengerService(IRepository<Passenger> repository) : IPassengerService
{
    /// <summary>
    /// Converts create DTO to entity
    /// </summary>
    private static Passenger MapDto(PassengerCreateDto entity)
    {
        return new Passenger
        {
            Id = 0,
            NumberOfPassport = entity.NumberOfPassport,
            FullName = entity.FullName,
            BirthDate = entity.BirthDate
        };
    }

    /// <summary>
    /// Converts entity to read DTO
    /// </summary>
    private static PassengerReadDto MapReadDto(Passenger entity) =>
        new(entity.Id, entity.NumberOfPassport, entity.FullName, entity.BirthDate);

    /// <summary>
    /// Create a new passenger record
    /// </summary>
    public async Task<PassengerReadDto> CreatePassengerAsync(PassengerCreateDto dto)
    {
        var id = await repository.CreateAsync(MapDto(dto));
        var created = await repository.ReadAsync(id);
        return MapReadDto(created!);
    }

    /// <summary>
    /// Get all passengers
    /// </summary>
    public async Task<List<PassengerReadDto>> GetPassengersAsync()
    {
        var entities = await repository.ReadAllAsync();
        return entities.Select(MapReadDto).ToList();
    }

    /// <summary>
    /// Get passenger by ID
    /// </summary>
    public async Task<PassengerReadDto?> GetPassengerAsync(int id)
    {
        var entity = await repository.ReadAsync(id);
        return entity == null ? null : MapReadDto(entity);
    }

    /// <summary>
    /// Update passenger by ID
    /// </summary>
    public async Task<PassengerReadDto?> UpdatePassengerAsync(int id, PassengerCreateDto dto)
    {
        var updated = await repository.UpdateAsync(id, MapDto(dto));
        return updated == null ? null : MapReadDto(updated);
    }

    /// <summary>
    /// Delete passenger by ID
    /// </summary>
    public async Task<bool> DeletePassengerAsync(int id)
    {
        return await repository.DeleteAsync(id);
    }
}