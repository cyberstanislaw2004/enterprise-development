using Airlines.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Api.Controllers;

/// <summary>
/// Controller exposing analytic endpoints
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AnalyticController(IAnalyticService _service) : ControllerBase
{
    /// <summary>
    /// Top 5 flights by number of passengers
    /// </summary>
    [HttpGet("top-five-flights")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetTopFiveFlights() =>
        Ok(await _service.GetTopFiveFlightsByPassengerCountAsync());

    /// <summary>
    /// Flights with minimum duration
    /// </summary>
    [HttpGet("min-duration-flights")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetMinDurationFlights() =>
        Ok(await _service.GetFlightsWithMinDurationAsync());

    /// <summary>
    /// Passengers on the flight with zero baggage, ordered by full name
    /// </summary>
    [HttpGet("flight/{flightNumber}/zero-baggage-passengers")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetPassengersWithZeroBaggage(string flightNumber) =>
        Ok(await _service.GetPassengersWithZeroBaggageOnFlightAsync(flightNumber));

    /// <summary>
    /// Summary of all flights of the model during period
    /// </summary>
    [HttpGet("model/{modelId}/flights")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetFlightsOfModelInPeriod(int modelId, [FromQuery] DateOnly? fromDate, [FromQuery] DateOnly? toDate) =>
        Ok(await _service.GetFlightsOfModelInPeriodAsync(modelId, fromDate, toDate));

    /// <summary>
    /// Flights by departure and arrival codes
    /// </summary>
    [HttpGet("route")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetFlightsByRoute([FromQuery] string departureCode, [FromQuery] string arrivalCode) =>
        Ok(await _service.GetFlightsByRouteAsync(departureCode, arrivalCode));
}