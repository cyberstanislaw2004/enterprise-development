namespace Airlines.Dto;

public record FlightCreateDto(
    string FlightNumber,
    string DepartureAirportCode,
    string DestinationAirportCode,
    DateOnly? DepartureDate,
    DateOnly? ArrivalDate,
    TimeOnly? DepartureTime,
    TimeSpan? Duration,
    AirplaneModelCreateDto AirplaneModel
);

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