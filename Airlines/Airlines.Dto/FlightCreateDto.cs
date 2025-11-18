namespace Airlines.Dto;

/// <summary>
/// DTO for create
/// </summary>
public record FlightCreateDto
{
    /// <summary>
    /// Unique flight code
    /// </summary>
    public string FlightNumber { get; init; }

    /// <summary>
    /// Origin point (eg LED)
    /// </summary>
    public string DepartureAirportCode { get; init; }

    /// <summary>
    /// Arrival point
    /// </summary>
    public string DestinationAirportCode { get; init; }

    /// <summary>
    /// Flight departure date 
    /// </summary>
    public DateOnly? DepartureDate { get; init; }

    /// <summary>
    /// Flight arrival date
    /// </summary>
    public DateOnly? ArrivalDate { get; init; }

    /// <summary>
    /// Flight departure time
    /// </summary>
    public TimeOnly? DepartureTime { get; init; }

    /// <summary>
    /// Travel time
    /// </summary>
    public TimeSpan? Duration { get; init; }

    /// <summary>
    /// Associated airplane model ID
    /// </summary>
    public int AirplaneModelId { get; init; }

    /// <summary>
    /// Create DTO constructor
    /// </summary>
    public FlightCreateDto(
        string flightNumber,
        string departureAirportCode,
        string destinationAirportCode,
        DateOnly? departureDate,
        DateOnly? arrivalDate,
        TimeOnly? departureTime,
        TimeSpan? duration,
        int airplaneModelId)
    {
        FlightNumber = flightNumber;
        DepartureAirportCode = departureAirportCode;
        DestinationAirportCode = destinationAirportCode;
        DepartureDate = departureDate;
        ArrivalDate = arrivalDate;
        DepartureTime = departureTime;
        Duration = duration;
        AirplaneModelId = airplaneModelId;
    }
}