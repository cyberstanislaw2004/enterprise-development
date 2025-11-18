namespace Airlines.Dto;

/// <summary>
/// DTO for create
/// </summary>
public record TicketCreateDto
{
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
    /// Flight ID
    /// </summary>
    public int FlightId { get; init; }

    /// <summary>
    /// Passenger ID
    /// </summary>
    public int PassengerId { get; init; }

    /// <summary>
    /// Create DTO constructor
    /// </summary>
    public TicketCreateDto(string seatNumber, bool handLuggageAvailability, double totalBaggageWeight, int flightId, int passengerId)
    {
        SeatNumber = seatNumber;
        HandLuggageAvailability = handLuggageAvailability;
        TotalBaggageWeight = totalBaggageWeight;
        FlightId = flightId;
        PassengerId = passengerId;
    }
}