namespace Airlines.Dto;

/// <summary>
/// DTO for read
/// </summary>
public record TicketReadDto
{
    /// <summary>
    /// Unique ID for the primary key in the database
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Flight information
    /// </summary>
    public FlightReadDto FlightInfo { get; init; }

    /// <summary>
    /// Passenger information
    /// </summary>
    public PassengerReadDto PassengerInfo { get; init; }

    /// <summary>
    /// Seat number
    /// </summary>
    public string SeatNumber { get; init; }

    /// <summary>
    /// Availability of hand luggage
    /// </summary>
    public bool HandLuggageAvailability { get; init; }

    /// <summary>
    /// Total luggage weight in kg
    /// </summary>
    public double TotalBaggageWeight { get; init; }

    /// <summary>
    /// DTO for read constructor
    /// </summary>
    public TicketReadDto(
        int id,
        FlightReadDto flightInfo,
        PassengerReadDto passengerInfo,
        string seatNumber,
        bool handLuggageAvailability,
        double totalBaggageWeight)
    {
        Id = id;
        FlightInfo = flightInfo;
        PassengerInfo = passengerInfo;
        SeatNumber = seatNumber;
        HandLuggageAvailability = handLuggageAvailability;
        TotalBaggageWeight = totalBaggageWeight;
    }
}