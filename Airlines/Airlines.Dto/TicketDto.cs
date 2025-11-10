namespace Airlines.Dto;

public record TicketCreateDto(
    FlightCreateDto FlightInfo,
    PassengerCreateDto PassengerInfo,
    string SeatNumber,
    bool HandLuggageAvailability,
    double TotalBaggageWeight
);

public record TicketReadDto(
    int Id,
    FlightReadDto FlightInfo,
    PassengerReadDto PassengerInfo,
    string SeatNumber,
    bool HandLuggageAvailability,
    double TotalBaggageWeight
);