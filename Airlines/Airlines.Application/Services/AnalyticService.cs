using Airlines.Application.Interfaces;
using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Dto;
using Airlines.Infrastructure.Db.Repositories;

namespace Airlines.Application.Services;

/// <summary>
/// Analytic service for processing and analyzing airline data
/// </summary>
public class AnalyticService(
    IRepository<Flight> flightRepository,
    IRepository<Ticket> ticketRepository,
    IRepository<Passenger> passengerRepository)
    : IAnalyticService
{
    /// <summary>
    /// Display the top 5 flights by the number of passengers carried.
    /// </summary>
    public async Task<List<FlightPassengerCountDto>> GetTopFiveFlightsByPassengerCountAsync()
    {
        var flights = await flightRepository.ReadAllAsync();
        var tickets = await ticketRepository.ReadAllAsync();

        int? GetFlightId(Ticket t) => t.FlightInfo?.Id ?? t.FlightId;

        var topFive = flights
            .Select(f => new FlightPassengerCountDto(f.FlightNumber, tickets.Count(t => GetFlightId(t) == f.Id)))
            .OrderByDescending(x => x.PassengerCount)
            .Take(5)
            .ToList();

        return topFive;
    }

    /// <summary>
    /// Display a list of flights with the minimum travel time.
    /// </summary>
    public async Task<List<FlightDurationDto>> GetFlightsWithMinDurationAsync()
    {
        var flights = await flightRepository.ReadAllAsync();
        var durations = flights.Where(f => f.Duration.HasValue).Select(f => f.Duration!.Value).ToList();
        if (!durations.Any()) return new List<FlightDurationDto>();

        var min = durations.Min();

        return flights
            .Where(f => f.Duration.HasValue && f.Duration.Value == min)
            .Select(f => new FlightDurationDto(f.FlightNumber, f.Duration))
            .ToList();
    }

    /// <summary>
    /// Display information about all passengers flying on the selected flight whose baggage weight is zero, sorted by full name.
    /// </summary>
    public async Task<List<PassengerReadDto>> GetPassengersWithZeroBaggageOnFlightAsync(string flightNumber)
    {
        var flights = await flightRepository.ReadAllAsync();
        var tickets = await ticketRepository.ReadAllAsync();
        var passengers = await passengerRepository.ReadAllAsync();

        var flight = flights.FirstOrDefault(f => f.FlightNumber == flightNumber);
        if (flight == null) return new List<PassengerReadDto>();

        var selectedTickets = tickets
            .Where(t => t.TotalBaggageWeight == 0 && (t.FlightInfo?.Id ?? t.FlightId) == flight.Id)
            .ToList();

        var result = selectedTickets
            .Select(t => passengers.FirstOrDefault(p => p.Id == (t.PassengerInfo?.Id ?? t.PassengerId)))
            .Where(p => p != null)
            .OrderBy(p => p!.FullName)
            .Select(p => new PassengerReadDto(p!.Id, p.NumberOfPassport, p.FullName, p.BirthDate))
            .ToList();

        return result;
    }

    /// <summary>
    /// Display summary information about all flights of aircraft of the selected model during a specified period of time.
    /// </summary>
    public async Task<List<FlightSummaryDto>> GetFlightsOfModelInPeriodAsync(int modelId, DateOnly? fromDate, DateOnly? toDate)
    {
        var flights = await flightRepository.ReadAllAsync();

        bool InPeriod(DateOnly? d)
        {
            if (!d.HasValue) return false;
            if (fromDate.HasValue && d.Value < fromDate.Value) return false;
            if (toDate.HasValue && d.Value > toDate.Value) return false;
            return true;
        }

        return flights
            .Where(f => (f.AirplaneModel?.Id ?? f.AirplaneModelId) == modelId &&
                        ((!fromDate.HasValue && !toDate.HasValue) || InPeriod(f.DepartureDate) || InPeriod(f.ArrivalDate)))
            .Select(f => new FlightSummaryDto(
                f.FlightNumber,
                f.DepartureAirportCode,
                f.DestinationAirportCode,
                f.DepartureDate,
                f.ArrivalDate,
                f.DepartureTime,
                f.Duration))
            .ToList();
    }

    /// <summary>
    /// Display information about all flights departing from a specified departure point to a specified arrival point.
    /// </summary>
    public async Task<List<FlightReadDto>> GetFlightsByRouteAsync(string departureCode, string arrivalCode)
    {
        var flights = await flightRepository.ReadAllAsync();

        return flights
            .Where(f => string.Equals(f.DepartureAirportCode, departureCode, StringComparison.OrdinalIgnoreCase)
                        && string.Equals(f.DestinationAirportCode, arrivalCode, StringComparison.OrdinalIgnoreCase))
            .Select(MapToFlightReadDto)
            .ToList();
    }

    private static FlightReadDto MapToFlightReadDto(Flight entity)
    {
        var model = entity.AirplaneModel;
        var family = model?.AirplaneFamily;

        var familyDto = family != null
            ? new AirplaneFamilyReadDto(family.Id, family.Name, family.Manufacturer)
            : new AirplaneFamilyReadDto(0, string.Empty, string.Empty);

        var modelDto = model != null
            ? new AirplaneModelReadDto(model.Id, model.ModelName, familyDto, model.RangeOfFlight, model.PassengerCapacity, model.CargoCapacity)
            : new AirplaneModelReadDto(0, string.Empty, familyDto, 0, 0, 0);

        return new FlightReadDto(
            entity.Id,
            entity.FlightNumber,
            entity.DepartureAirportCode,
            entity.DestinationAirportCode,
            entity.DepartureDate,
            entity.ArrivalDate,
            entity.DepartureTime,
            entity.Duration,
            modelDto
        );
    }
}