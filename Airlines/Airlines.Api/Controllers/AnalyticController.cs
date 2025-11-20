using Airlines.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Api.Controllers;

/// <summary>
/// Controller exposing analytic endpoints
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AnalyticController(AnalyticService _service) : ControllerBase
{
    /// <summary>
    /// Top 5 flights by number of passengers
    /// </summary>
    [HttpGet("top-five-flights")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult GetTopFiveFlights() =>
        Ok(_service.GetTopFiveFlightsByPassengerCount());

    /// <summary>
    /// Flights with minimum duration
    /// </summary>
    [HttpGet("min-duration-flights")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult GetMinDurationFlights() =>
        Ok(_service.GetFlightsWithMinDuration());

    /// <summary>
    /// Passengers on the flight with zero baggage, ordered by full name
    /// </summary>
    [HttpGet("flight/{flightNumber}/zero-baggage-passengers")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult GetPassengersWithZeroBaggage(string flightNumber) =>
        Ok(_service.GetPassengersWithZeroBaggageOnFlight(flightNumber));

    /// <summary>
    /// Summary of all flights of the model during period
    /// </summary>
    [HttpGet("model/{modelId}/flights")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult GetFlightsOfModelInPeriod(int modelId, [FromQuery] DateOnly? fromDate, [FromQuery] DateOnly? toDate) =>
        Ok(_service.GetFlightsOfModelInPeriod(modelId, fromDate, toDate));

    /// <summary>
    /// Flights by departure and arrival codes
    /// </summary>
    [HttpGet("route")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult GetFlightsByRoute([FromQuery] string departureCode, [FromQuery] string arrivalCode) =>
        Ok(_service.GetFlightsByRoute(departureCode, arrivalCode));
}