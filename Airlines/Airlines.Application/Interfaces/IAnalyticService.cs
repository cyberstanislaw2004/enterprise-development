using Airlines.Dto;

namespace Airlines.Application.Interfaces;

/// <summary>
/// Analytic interface for processing and analyzing airline data
/// </summary>
public interface IAnalyticService
{
    /// <summary>
    /// Display the top 5 flights by the number of passengers carried.
    /// </summary>
    public Task<List<FlightPassengerCountDto>> GetTopFiveFlightsByPassengerCountAsync();

    /// <summary>
    /// Display a list of flights with the minimum travel time.
    /// </summary>
    public Task<List<FlightDurationDto>> GetFlightsWithMinDurationAsync();

    /// <summary>
    /// Display information about all passengers flying on the selected flight whose baggage weight is zero, sorted by full name.
    /// </summary>
    public Task<List<PassengerReadDto>> GetPassengersWithZeroBaggageOnFlightAsync(string flightNumber);

    /// <summary>
    /// Display summary information about all flights of aircraft of the selected model during a specified period of time.
    /// </summary>
    public Task<List<FlightSummaryDto>> GetFlightsOfModelInPeriodAsync(int modelId, DateOnly? fromDate, DateOnly? toDate);

    /// <summary>
    /// Display information about all flights departing from a specified departure point to a specified arrival point.
    /// </summary>
    public Task<List<FlightReadDto>> GetFlightsByRouteAsync(string departureCode, string arrivalCode);
}
