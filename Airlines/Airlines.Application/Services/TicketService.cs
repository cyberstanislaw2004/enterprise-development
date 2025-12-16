using Airlines.Application.Interfaces;
using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Dto;

namespace Airlines.Application.Services;

/// <summary>
/// Service for managing passengers entities
/// </summary>
public class TicketService(IRepository<Ticket> _ticketRepository, IRepository<Flight> _flightRepository, IRepository<Passenger> _passengerRepository) : ITicketService
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
            //FlightInfo = flight,
            PassengerId = passenger.Id,
            //PassengerInfo = passenger,
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
                entity.FlightInfo!.Id,
                entity.FlightInfo.FlightNumber,
                entity.FlightInfo.DepartureAirportCode,
                entity.FlightInfo.DestinationAirportCode,
                entity.FlightInfo.DepartureDate,
                entity.FlightInfo.ArrivalDate,
                entity.FlightInfo.DepartureTime,
                entity.FlightInfo.Duration,
                new AirplaneModelReadDto(
                    entity.FlightInfo.AirplaneModel!.Id,
                    entity.FlightInfo.AirplaneModel.ModelName,
                    new AirplaneFamilyReadDto(
                        entity.FlightInfo.AirplaneModel.AirplaneFamily!.Id,
                        entity.FlightInfo.AirplaneModel.AirplaneFamily.Name,
                        entity.FlightInfo.AirplaneModel.AirplaneFamily.Manufacturer
                    ),
                    entity.FlightInfo.AirplaneModel.RangeOfFlight,
                    entity.FlightInfo.AirplaneModel.PassengerCapacity,
                    entity.FlightInfo.AirplaneModel.CargoCapacity
                )
            ),
            new PassengerReadDto(
                entity.PassengerInfo!.Id,
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
    public async Task<TicketReadDto> CreateTicketAsync(TicketCreateDto dto)
    {
        var flight = await _flightRepository.ReadAsync(dto.FlightId)
                 ?? throw new ArgumentException("Invalid Flight ID");

        var passenger = await _passengerRepository.ReadAsync(dto.PassengerId)
                        ?? throw new ArgumentException("Invalid Passenger ID");

        var ticket = MapDto(dto, flight, passenger);
        var id = await _ticketRepository.CreateAsync(ticket);

        var createdTicket = await _ticketRepository.ReadAsync(id);
        return MapReadDto(createdTicket!);
    }

    /// <summary>
    /// Get all tickets
    /// </summary>
    public async Task<List<TicketReadDto>> GetTicketsAsync() =>
        (await _ticketRepository.ReadAllAsync()).Select(MapReadDto).ToList();

    /// <summary>
    /// Get ticket by ID
    /// </summary>
    public async Task<TicketReadDto?> GetTicketAsync(int id)
    {
        var ticket = await _ticketRepository.ReadAsync(id);
        return ticket == null ? null : MapReadDto(ticket);
    }

    /// <summary>
    /// Update ticket by ID
    /// </summary>
    public async Task<TicketReadDto?> UpdateTicketAsync(int id, TicketCreateDto dto)
    {
        var flight = await _flightRepository.ReadAsync(dto.FlightId)
                 ?? throw new ArgumentException("Invalid Flight ID");

        var passenger = await _passengerRepository.ReadAsync(dto.PassengerId)
                        ?? throw new ArgumentException("Invalid Passenger ID");

        var ticket = MapDto(dto, flight, passenger);
        var updated = await _ticketRepository.UpdateAsync(id, ticket);

        if (updated == null)
            return null;

        var updatedTicket = await _ticketRepository.ReadAsync(id);
        return MapReadDto(updatedTicket!);
    }

    /// <summary>
    /// Delete ticket by ID
    /// </summary>
    public async Task<bool> DeleteTicketAsync(int id) =>
        await _ticketRepository.DeleteAsync(id);
}