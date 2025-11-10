using Airlines.Application.Dto;
using Airlines.Domain;
using Airlines.Domain.Repositories;

namespace Airlines.Application.Services;

public class TicketService(ITicketRepository repository)
{
    private static Ticket MapDto(TicketDto entity, Flight flight, Passenger passenger)
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

    public int CreateTicket(TicketDto entity, Flight flight, Passenger passenger)
    {
        return repository.Create(MapDto(entity, flight, passenger));
    }

    public List<Ticket> GetTickets()
    {
        return repository.Read();
    }

    public Ticket? GetTicket(int id)
    {
        return repository.Read(id);
    }

    public Ticket? UpdateTicket(int id, TicketDto entity, Flight flight, Passenger passenger)
    {
        return repository.Update(id, MapDto(entity, flight, passenger));
    }

    public bool DeleteTicket(int id)
    {
        return repository.Delete(id);
    }
}
