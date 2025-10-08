namespace Airlines.Application.Dto;

/// <summary>
/// Class characterizing a ticket
/// </summary>
public class TicketDto
{
    /// <summary>
    /// Flight information
    /// </summary>
    public required FlightDto FlightInfo { get; set; }

    /// <summary>
    /// Passenger information
    /// </summary>
    public required PassengerDto PassengerInfo { get; set; }

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
