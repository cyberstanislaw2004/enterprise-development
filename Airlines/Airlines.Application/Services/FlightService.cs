using Airlines.Dto;
using Airlines.Domain;
using Airlines.Domain.Repositories;

namespace Airlines.Application.Services;

/// <summary>
/// Service for managing flights entities
/// </summary>
public class FlightService(IRepository<Flight> repository)
{
    /// <summary>
    /// Converts create DTO to entity
    /// </summary>
    private static Flight MapDto(FlightCreateDto entity, AirplaneModel model)
    {
        return new Flight
        {
            Id = 0,
            FlightNumber = entity.FlightNumber,
            DepartureAirportCode = entity.DepartureAirportCode,
            DestinationAirportCode = entity.DestinationAirportCode,
            DepartureDate = entity.DepartureDate,
            ArrivalDate = entity.ArrivalDate,
            DepartureTime = entity.DepartureTime,
            Duration = entity.Duration,
            AirplaneModelId = model.Id,
            AirplaneModel = model
        };
    }

    /// <summary>
    /// Converts entity to read DTO
    /// </summary>
    private static FlightReadDto MapReadDto(Flight entity) =>
        new(
        entity.Id,
        entity.FlightNumber,
        entity.DepartureAirportCode,
        entity.DestinationAirportCode,
        entity.DepartureDate,
        entity.ArrivalDate,
        entity.DepartureTime,
        entity.Duration,
        new AirplaneModelReadDto(
            entity.AirplaneModel.Id,
            entity.AirplaneModel.ModelName,
            new AirplaneFamilyReadDto(
                entity.AirplaneModel.AirplaneFamily.Id,
                entity.AirplaneModel.AirplaneFamily.Name,
                entity.AirplaneModel.AirplaneFamily.Manufacturer
            ),
            entity.AirplaneModel.RangeOfFlight,
            entity.AirplaneModel.PassengerCapacity,
            entity.AirplaneModel.CargoCapacity
        )
    );

    /// <summary>
    /// Create a new flight record
    /// </summary>
    public int CreateFlight(FlightCreateDto entity, AirplaneModel model) =>
        repository.Create(MapDto(entity, model));

    /// <summary>
    /// Get all flights
    /// </summary>
    public List<FlightReadDto> GetFlights() =>
        repository.Read().Select(MapReadDto).ToList();

    /// <summary>
    /// Get flight by ID
    /// </summary>
    public FlightReadDto? GetFlight(int id)
    {
        var entity = repository.Read(id);

        if (entity == null)
            return null;
        else
            return MapReadDto(entity);
    }

    /// <summary>
    /// Update flight by ID
    /// </summary>
    public Flight? UpdateFlight(int id, FlightCreateDto entity, AirplaneModel model) =>
        repository.Update(id, MapDto(entity, model));

    /// <summary>
    /// Delete flight by ID
    /// </summary>
    public bool DeleteFlight(int id) =>
        repository.Delete(id);
}