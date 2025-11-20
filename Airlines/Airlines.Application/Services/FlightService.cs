using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Dto;

namespace Airlines.Application.Services;

/// <summary>
/// Service for managing flights entities
/// </summary>
public class FlightService(IRepository<Flight> _flightRepository, IRepository<AirplaneModel> _modelRepository)
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
    public int CreateFlight(FlightCreateDto dto)
    {
        var model = _modelRepository.Read(dto.AirplaneModelId);
        if (model == null)
            throw new ArgumentException("Invalid AirplaneModel ID");

        var entity = new Flight
        {
            Id = 0,
            FlightNumber = dto.FlightNumber,
            DepartureAirportCode = dto.DepartureAirportCode,
            DestinationAirportCode = dto.DestinationAirportCode,
            DepartureDate = dto.DepartureDate,
            ArrivalDate = dto.ArrivalDate,
            DepartureTime = dto.DepartureTime,
            Duration = dto.Duration,
            AirplaneModelId = model.Id,
            AirplaneModel = null // не присваиваем объект модели напрямую
        };

        return _flightRepository.Create(entity);
    }

    /// <summary>
    /// Get all flights
    /// </summary>
    public List<FlightReadDto> GetFlights() =>
        _flightRepository.Read().Select(MapReadDto).ToList();

    /// <summary>
    /// Get flight by ID
    /// </summary>
    public FlightReadDto? GetFlight(int id)
    {
        var entity = _flightRepository.Read(id);

        if (entity == null)
            return null;
        else
            return MapReadDto(entity);
    }

    /// <summary>
    /// Update flight by ID
    /// </summary>
    public Flight? UpdateFlight(int id, FlightCreateDto dto)
    {
        {
            var model = _modelRepository.Read(dto.AirplaneModelId);
            if (model == null)
                throw new ArgumentException("Invalid AirplaneModel ID");

            var entity = new Flight
            {
                Id = 0,
                FlightNumber = dto.FlightNumber,
                DepartureAirportCode = dto.DepartureAirportCode,
                DestinationAirportCode = dto.DestinationAirportCode,
                DepartureDate = dto.DepartureDate,
                ArrivalDate = dto.ArrivalDate,
                DepartureTime = dto.DepartureTime,
                Duration = dto.Duration,
                AirplaneModelId = model.Id,
                AirplaneModel = null
            };

            return _flightRepository.Update(id, entity);
        }
    }

    /// <summary>
    /// Delete flight by ID
    /// </summary>
    public bool DeleteFlight(int id) =>
        _flightRepository.Delete(id);
}