namespace Airlines.Dto;

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