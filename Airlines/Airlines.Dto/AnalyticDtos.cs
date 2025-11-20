namespace Airlines.Dto;

/// <summary>
/// DTOs for analytic endpoints
/// </summary>
public static class AnalyticDtos { }

/// <summary>
/// Flight and passenger count
/// </summary>
public record FlightPassengerCountDto(string FlightNumber, int PassengerCount);

/// <summary>
/// Flight and duration
/// </summary>
public record FlightDurationDto(string FlightNumber, TimeSpan? Duration);

/// <summary>
/// Flight summary for model+period query
/// </summary>
public record FlightSummaryDto(
    string FlightNumber,
    string DepartureAirportCode,
    string DestinationAirportCode,
    DateOnly? DepartureDate,
    DateOnly? ArrivalDate,
    TimeOnly? DepartureTime,
    TimeSpan? Duration);

/// <summary>
/// Flight and average baggage weight
/// </summary>
public record FlightBaggageAvgDto(string FlightNumber, double AverageBaggageWeight);