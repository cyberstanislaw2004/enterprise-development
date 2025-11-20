namespace Airlines.Domain;

/// <summary>
/// Class that stores flight information
/// </summary>
public class Flight
{
    /// <summary>
    /// Unique ID for the primary key in the database
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Unique flight code
    /// </summary>
    public required string FlightNumber { get; set; }

    /// <summary>
    /// Origin point (eg LED)
    /// </summary>
    public required string DepartureAirportCode { get; set; }

    /// <summary>
    /// Arrival point
    /// </summary>
    public required string DestinationAirportCode { get; set; }

    /// <summary>
    /// Flight departure date 
    /// </summary>
    public DateOnly? DepartureDate { get; set; }

    /// <summary>
    /// Flight arrival date
    /// </summary>
    public DateOnly? ArrivalDate { get; set; }

    /// <summary>
    /// Flight departure time
    /// </summary>
    public TimeOnly? DepartureTime { get; set; }

    /// <summary>
    /// Travel time
    /// </summary>
    public TimeSpan? Duration { get; set; }

    /// <summary>
    /// Foreign key to the airplane model
    /// </summary>
    public required int AirplaneModelId { get; set; }

    /// <summary>
    /// Airplane model
    /// </summary>
    public virtual AirplaneModel? AirplaneModel { get; set; }
}