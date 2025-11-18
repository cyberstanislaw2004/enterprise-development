namespace Airlines.Dto;

/// <summary>
/// DTO for read
/// </summary>
public record FlightReadDto(
    int Id,
    string FlightNumber,
    string DepartureAirportCode,
    string DestinationAirportCode,
    DateOnly? DepartureDate,
    DateOnly? ArrivalDate,
    TimeOnly? DepartureTime,
    TimeSpan? Duration,
    AirplaneModelReadDto AirplaneModel
);