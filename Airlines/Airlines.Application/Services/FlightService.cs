using Airlines.Application.Dto;
using Airlines.Domain;
using Airlines.Domain.Repositories;

namespace Airlines.Application.Services;

public class FlightService(IFlightRepository repository)
{
    private static Flight MapDto(FlightDto entity, AirplaneModel model)
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
            AirplaneModel = model
        };
    }

    public int CreateAirplaneFamily(FlightDto entity, AirplaneModel model)
    {
        return repository.Create(MapDto(entity, model));
    }

    public List<Flight> GetFlights()
    {
        return repository.Read();
    }

    public Flight? GetFlight(int id)
    {
        return repository.Read(id);
    }

    public Flight? UpdateFlight(int id, FlightDto entity, AirplaneModel model)
    {
        return repository.Update(id, MapDto(entity, model));
    }

    public bool DeleteFlight(int id)
    {
        return repository.Delete(id);
    }
}
