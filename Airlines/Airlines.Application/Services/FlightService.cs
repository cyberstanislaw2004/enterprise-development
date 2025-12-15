using Airlines.Application.Interfaces;
using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Dto;

namespace Airlines.Application.Services;

/// <summary>
/// Service for managing flights entities
/// </summary>
public class FlightService(IRepository<Flight> _flightRepository, IRepository<AirplaneModel> _modelRepository) : IFlightService
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
            entity.AirplaneModel!.Id,
            entity.AirplaneModel.ModelName,
            new AirplaneFamilyReadDto(
                entity.AirplaneModel.AirplaneFamily!.Id,
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
    public async Task<FlightReadDto> CreateFlightAsync(FlightCreateDto dto)
    {
        var model = await _modelRepository.ReadAsync(dto.AirplaneModelId);
        if (model == null)
            throw new ArgumentException("Invalid AirplaneModel ID");

        var entity = MapDto(dto, model);
        var id = await _flightRepository.CreateAsync(entity);
        var created = await _flightRepository.ReadAsync(id);

        return MapReadDto(created!);
    }

    /// <summary>
    /// Get all flights
    /// </summary>
    public async Task<List<FlightReadDto>> GetFlightsAsync()
    {
        var flights = await _flightRepository.ReadAllAsync();
        return flights.Select(MapReadDto).ToList();
    }

    /// <summary>
    /// Get flight by ID
    /// </summary>
    public async Task<FlightReadDto?> GetFlightAsync(int id)
    {
        var entity = await _flightRepository.ReadAsync(id);
        return entity == null ? null : MapReadDto(entity);
    }

    /// <summary>
    /// Get all flights for a specific airplane model
    /// </summary>
    public async Task<List<FlightReadDto>> GetFlightsByAirplaneModelIdAsync(int airplaneModelId)
    {
        var flights = await _flightRepository.ReadAllAsync();

        // фильтруем по модели самолета
        var filteredFlights = flights
            .Where(f => f.AirplaneModelId == airplaneModelId)
            .ToList();

        return filteredFlights.Select(MapReadDto).ToList();
    }

    /// <summary>
    /// Update flight by ID
    /// </summary>
    public async Task<FlightReadDto?> UpdateFlightAsync(int id, FlightCreateDto dto)
    {
        var model = await _modelRepository.ReadAsync(dto.AirplaneModelId);
        if (model == null)
            throw new ArgumentException("Invalid AirplaneModel ID");

        var entity = MapDto(dto, model);
        var updated = await _flightRepository.UpdateAsync(id, entity);

        return updated == null ? null : MapReadDto(updated);
    }

    /// <summary>
    /// Delete flight by ID
    /// </summary>
    public async Task<bool> DeleteFlightAsync(int id)
    {
        return await _flightRepository.DeleteAsync(id);
    }
}