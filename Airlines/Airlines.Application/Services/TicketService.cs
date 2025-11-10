using Airlines.Dto;
using Airlines.Domain;
using Airlines.Domain.Repositories;

namespace Airlines.Application.Services;

public class TicketService(IRepository<Ticket> repository)
{
    private static Ticket MapDto(TicketCreateDto entity, Flight flight, Passenger passenger)
    {
        return new Ticket
        {
            Id = 0,
            FlightInfo = flight,
            PassengerInfo = passenger,
            SeatNumber = entity.SeatNumber,
            HandLuggageAvailability = entity.HandLuggageAvailability,
            TotalBaggageWeight = entity.TotalBaggageWeight
        };
    }

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

    public int CreateTicket(TicketCreateDto entity, Flight flight, Passenger passenger) =>
        repository.Create(MapDto(entity, flight, passenger));

    public List<TicketReadDto> GetTickets() =>
        repository.Read().Select(MapReadDto).ToList();

    public TicketReadDto? GetTicket(int id)
    {
        var entity = repository.Read(id);

        if (entity == null)
            return null;
        else
            return MapReadDto(entity);
    }

    public Ticket? UpdateTicket(int id, TicketCreateDto entity, Flight flight, Passenger passenger) =>
        repository.Update(id, MapDto(entity, flight, passenger));

    public bool DeleteTicket(int id) =>
        repository.Delete(id);
}
