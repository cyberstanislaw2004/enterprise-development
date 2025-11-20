namespace Airlines.Domain;

/// <summary>
/// Class characterizing a ticket
/// </summary>
public class Ticket
{
    /// <summary>
    /// Unique ID for the primary key in the database
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Foreign key to the flight
    /// </summary>
    public required int FlightId { get; set; }

    /// <summary>
    /// Flight information
    /// </summary>
    public virtual Flight? FlightInfo { get; set; }

    /// <summary>
    /// Foreign key to the passenger
    /// </summary>
    public required int PassengerId { get; set; }

    /// <summary>
    /// Passenger information
    /// </summary>
    public virtual Passenger? PassengerInfo { get; set; }

    /// <summary>
    /// Seat number
    /// </summary>
    public required string SeatNumber { get; set; }

    /// <summary>
    /// Availability of hand luggage
    /// </summary>
    public required bool HandLuggageAvailability { get; set; }

    /// <summary>
    /// Total luggage weight in kg
    /// </summary>
    public required double TotalBaggageWeight { get; set; }
}