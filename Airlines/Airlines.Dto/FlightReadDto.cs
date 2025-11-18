namespace Airlines.Dto;

/// <summary>
/// DTO for read
/// </summary>
public record FlightReadDto
{
    /// <summary>
    /// Unique ID for the primary key in the database
    /// </summary>
    public int Id { get; init; }

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
    /// Associated airplane model
    /// </summary>
    public AirplaneModelReadDto AirplaneModel { get; init; }

    /// <summary>
    /// DTO for read constructor
    /// </summary>
    public FlightReadDto(
        int id,
        string flightNumber,
        string departureAirportCode,
        string destinationAirportCode,
        DateOnly? departureDate,
        DateOnly? arrivalDate,
        TimeOnly? departureTime,
        TimeSpan? duration,
        AirplaneModelReadDto airplaneModel)
    {
        Id = id;
        FlightNumber = flightNumber;
        DepartureAirportCode = departureAirportCode;
        DestinationAirportCode = destinationAirportCode;
        DepartureDate = departureDate;
        ArrivalDate = arrivalDate;
        DepartureTime = departureTime;
        Duration = duration;
        AirplaneModel = airplaneModel;
    }
}