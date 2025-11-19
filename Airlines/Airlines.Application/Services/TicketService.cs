using Airlines.Dto;
using Airlines.Domain;
using Airlines.Domain.Repositories;

namespace Airlines.Application.Services;

/// <summary>
/// Service for managing passengers entities
/// </summary>
public class TicketService(IRepository<Ticket> repository)
{
    /// <summary>
    /// Converts create DTO to entity
    /// </summary>
    private static Ticket MapDto(TicketCreateDto entity, Flight flight, Passenger passenger)
    {
        return new Ticket
        {
            Id = 0,
            FlightId = flight.Id,
            FlightInfo = flight,
            PassengerId = passenger.Id,
            PassengerInfo = passenger,
            SeatNumber = entity.SeatNumber,
            HandLuggageAvailability = entity.HandLuggageAvailability,
            TotalBaggageWeight = entity.TotalBaggageWeight
        };
    }

    /// <summary>
    /// Converts entity to read DTO
    /// </summary>
    private static TicketReadDto MapReadDto(Ticket entity) =>
        new(
            entity.Id,
            new FlightReadDto(
                entity.FlightInfo.Id,
                entity.FlightInfo.FlightNumber,
                entity.FlightInfo.DepartureAirportCode,
                entity.FlightInfo.DestinationAirportCode,
                entity.FlightInfo.DepartureDate,
                entity.FlightInfo.ArrivalDate,
                entity.FlightInfo.DepartureTime,
                entity.FlightInfo.Duration,
                new AirplaneModelReadDto(
                    entity.FlightInfo.AirplaneModel.Id,
                    entity.FlightInfo.AirplaneModel.ModelName,
                    new AirplaneFamilyReadDto(
                        entity.FlightInfo.AirplaneModel.AirplaneFamily.Id,
                        entity.FlightInfo.AirplaneModel.AirplaneFamily.Name,
                        entity.FlightInfo.AirplaneModel.AirplaneFamily.Manufacturer
                    ),
                    entity.FlightInfo.AirplaneModel.RangeOfFlight,
                    entity.FlightInfo.AirplaneModel.PassengerCapacity,
                    entity.FlightInfo.AirplaneModel.CargoCapacity
                )
            ),
            new PassengerReadDto(
                entity.PassengerInfo.Id,
                entity.PassengerInfo.NumberOfPassport,
                entity.PassengerInfo.FullName,
                entity.PassengerInfo.BirthDate
            ),
            entity.SeatNumber,
            entity.HandLuggageAvailability,
            entity.TotalBaggageWeight
        );

    /// <summary>
    /// Create a new ticket record
    /// </summary>
    public int CreateTicket(TicketCreateDto entity, Flight flight, Passenger passenger) =>
        repository.Create(MapDto(entity, flight, passenger));

    /// <summary>
    /// Get all tickets
    /// </summary>
    public List<TicketReadDto> GetTickets() =>
        repository.Read().Select(MapReadDto).ToList();

    /// <summary>
    /// Get ticket by ID
    /// </summary>
    public TicketReadDto? GetTicket(int id)
    {
        var entity = repository.Read(id);

        if (entity == null)
            return null;
        else
            return MapReadDto(entity);
    }

    /// <summary>
    /// Update ticket by ID
    /// </summary>
    public Ticket? UpdateTicket(int id, TicketCreateDto entity, Flight flight, Passenger passenger) =>
        repository.Update(id, MapDto(entity, flight, passenger));

    /// <summary>
    /// Delete ticket by ID
    /// </summary>
    public bool DeleteTicket(int id) =>
        repository.Delete(id);
}