using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Dto;

namespace Airlines.Application.Services;

/// <summary>
/// Analytic service for processing and analyzing airline data
/// </summary>
public class AnalyticService(
    IRepository<Flight> flightRepository,
    IRepository<Ticket> ticketRepository,
    IRepository<Passenger> passengerRepository)
{
    /// <summary>
    /// Display the top 5 flights by the number of passengers carried.
    /// </summary>
    public List<FlightPassengerCountDto> GetTopFiveFlightsByPassengerCount()
    {
        var flights = flightRepository.Read();
        var tickets = ticketRepository.Read();

        int? GetFlightId(Ticket t)
        {
            var p = t.GetType().GetProperty("FlightId");
            if (p != null)
            {
                var v = p.GetValue(t);
                if (v is int i) return i;
                if (v is int ni) return ni;
            }
            return t.FlightInfo?.Id;
        }

        var topFive = (
            from f in flights
            let cnt = tickets.Count(t => GetFlightId(t) == f.Id)
            orderby cnt descending
            select new FlightPassengerCountDto(f.FlightNumber, cnt)
        )
        .Take(5)
        .ToList();

        return topFive;
    }

    /// <summary>
    /// Display a list of flights with the minimum travel time.
    /// </summary>
    public List<FlightDurationDto> GetFlightsWithMinDuration()
    {
        var flights = flightRepository.Read();
        var durations = flights.Where(f => f.Duration.HasValue).Select(f => f.Duration!.Value).ToList();
        if (!durations.Any()) return new List<FlightDurationDto>();

        var min = durations.Min();

        var result = flights
            .Where(f => f.Duration.HasValue && f.Duration.Value == min)
            .Select(f => new FlightDurationDto(f.FlightNumber, f.Duration))
            .ToList();

        return result;
    }

    /// <summary>
    /// Display information about all passengers flying on the selected flight whose baggage weight is zero, sorted by full name.
    /// </summary>
    public List<PassengerReadDto> GetPassengersWithZeroBaggageOnFlight(string flightNumber)
    {
        var flights = flightRepository.Read();
        var tickets = ticketRepository.Read();
        var passengers = passengerRepository.Read();

        var flight = flights.FirstOrDefault(f => f.FlightNumber == flightNumber);
        if (flight == null) return new List<PassengerReadDto>();

        int? GetFlightId(Ticket t)
        {
            var p = t.GetType().GetProperty("FlightId");
            if (p != null)
            {
                var v = p.GetValue(t);
                if (v is int i) return i;
                if (v is int ni) return ni;
            }
            return t.FlightInfo?.Id;
        }

        int? GetPassengerId(Ticket t)
        {
            var p = t.GetType().GetProperty("PassengerId");
            if (p != null)
            {
                var v = p.GetValue(t);
                if (v is int i) return i;
                if (v is int ni) return ni;
            }
            return t.PassengerInfo?.Id;
        }

        var selectedTickets = tickets
            .Where(t => t.TotalBaggageWeight == 0 && GetFlightId(t) == flight.Id)
            .ToList();

        var result = (
            from t in selectedTickets
            let pid = GetPassengerId(t)
            where pid.HasValue
            join p in passengers on pid.Value equals p.Id
            orderby p.FullName
            select new PassengerReadDto(p.Id, p.NumberOfPassport, p.FullName, p.BirthDate)
        ).ToList();

        return result;
    }

    /// <summary>
    /// Display summary information about all flights of aircraft of the selected model during a specified period of time.
    /// </summary>
    public List<FlightSummaryDto> GetFlightsOfModelInPeriod(int modelId, DateOnly? fromDate, DateOnly? toDate)
    {
        var flights = flightRepository.Read();

        bool InPeriod(DateOnly? d)
        {
            if (!d.HasValue) return false;
            if (fromDate.HasValue && d.Value < fromDate.Value) return false;
            if (toDate.HasValue && d.Value > toDate.Value) return false;
            return true;
        }

        int? GetModelId(Flight f)
        {
            var p = f.GetType().GetProperty("AirplaneModelId");
            if (p != null)
            {
                var v = p.GetValue(f);
                if (v is int i) return i;
                if (v is int ni) return ni;
            }
            return f.AirplaneModel?.Id;
        }

        var result = (
            from f in flights
            let mid = GetModelId(f)
            where mid.HasValue && mid.Value == modelId
                  && ((!fromDate.HasValue && !toDate.HasValue) || InPeriod(f.DepartureDate) || InPeriod(f.ArrivalDate))
            select new FlightSummaryDto(
                f.FlightNumber,
                f.DepartureAirportCode,
                f.DestinationAirportCode,
                f.DepartureDate,
                f.ArrivalDate,
                f.DepartureTime,
                f.Duration)
        ).ToList();

        return result;
    }

    /// <summary>
    /// Display information about all flights departing from a specified departure point to a specified arrival point.
    /// </summary>
    public List<FlightReadDto> GetFlightsByRoute(string departureCode, string arrivalCode)
    {
        var flights = flightRepository.Read();

        var matched = flights
            .Where(f =>
                string.Equals(f.DepartureAirportCode, departureCode, StringComparison.OrdinalIgnoreCase)
                && string.Equals(f.DestinationAirportCode, arrivalCode, StringComparison.OrdinalIgnoreCase))
            .Select(f => MapToFlightReadDto(f))
            .ToList();

        return matched;
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