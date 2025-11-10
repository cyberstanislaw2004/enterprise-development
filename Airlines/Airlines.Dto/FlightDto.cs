namespace Airlines.Dto;

/// <summary>
/// DTO for create
/// </summary>
public record FlightCreateDto(
    string FlightNumber,
    string DepartureAirportCode,
    string DestinationAirportCode,
    DateOnly? DepartureDate,
    DateOnly? ArrivalDate,
    TimeOnly? DepartureTime,
    TimeSpan? Duration,
    AirplaneModelCreateDto AirplaneModel,
    int AirplaneModelId
);

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