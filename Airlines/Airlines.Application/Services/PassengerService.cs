using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Dto;

namespace Airlines.Application.Services;

/// <summary>
/// Service for managing passengers entities
/// </summary>
public class PassengerService(IRepository<Passenger> repository)
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
    public int CreatePassenger(PassengerCreateDto entity) =>
        repository.Create(MapDto(entity));

    /// <summary>
    /// Get all passengers
    /// </summary>
    public List<PassengerReadDto> GetPassengers() =>
        repository.Read().Select(MapReadDto).ToList();

    /// <summary>
    /// Get passenger by ID
    /// </summary>
    public PassengerReadDto? GetPassenger(int id)
    {
        var entity = repository.Read(id);

        if (entity == null)
            return null;
        else
            return MapReadDto(entity);
    }

    /// <summary>
    /// Update passenger by ID
    /// </summary>
    public Passenger? UpdatePassenger(int id, PassengerCreateDto entity) =>
        repository.Update(id, MapDto(entity));

    /// <summary>
    /// Delete passenger by ID
    /// </summary>
    public bool DeletePassenger(int id) =>
        repository.Delete(id);
}