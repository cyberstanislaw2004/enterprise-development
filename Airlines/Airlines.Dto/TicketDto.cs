namespace Airlines.Dto;

/// <summary>
/// DTO for create
/// </summary>
public record TicketCreateDto(
    FlightCreateDto FlightInfo,
    PassengerCreateDto PassengerInfo,
    string SeatNumber,
    bool HandLuggageAvailability,
    double TotalBaggageWeight,
    int FlightId,
    int PassengerId
);

/// <summary>
/// DTO for read
/// </summary>
public record TicketReadDto(
    int Id,
    FlightReadDto FlightInfo,
    PassengerReadDto PassengerInfo,
    string SeatNumber,
    bool HandLuggageAvailability,
    double TotalBaggageWeight
);