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
    /// Flight information
    /// </summary>
    public required Flight FlightInfo { get; set; }

    /// <summary>
    /// Passenger information
    /// </summary>
    public required Passenger PassengerInfo { get; set; }

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
