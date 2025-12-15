using Airlines.Application.Interfaces;
using Airlines.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Api.Controllers;

/// <summary>
/// Controller for managing flights
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class FlightController(IFlightService _service, ITicketService _ticketService) : ControllerBase
{
    /// <summary>
    /// Returns a list of all flights
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<FlightReadDto>), 200)]
    public async Task<ActionResult<List<FlightReadDto>>> GetAll()
    {
        var flights = await _service.GetFlightsAsync();
        return Ok(flights);
    }

    /// <summary>
    /// Returns information about flight by id
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(FlightReadDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<FlightReadDto>> Get(int id)
    {
        var entity = await _service.GetFlightAsync(id);

        if (entity == null)
            return NotFound();

        return Ok(entity);
    }

    /// <summary>
    /// Returns all tickets for this flight
    /// </summary>
    [HttpGet("{id}/tickets")]
    [ProducesResponseType(typeof(List<TicketReadDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<List<TicketReadDto>>> GetTickets(int id)
    {
        var flight = await _service.GetFlightAsync(id);
        if (flight == null)
            return NotFound();

        var tickets = (await _ticketService.GetTicketsAsync())
            .Where(t => t.FlightInfo.Id == id)
            .ToList();

        return Ok(tickets);
    }

    /// <summary>
    /// Create a new flight
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(FlightReadDto), 201)]
    public async Task<ActionResult<FlightReadDto>> Create([FromBody] FlightCreateDto dto)
    {
        try
        {
            var created = await _service.CreateFlightAsync(dto);

            return CreatedAtAction(
                nameof(Get),
                new { id = created.Id },
                created
            );
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Update flight by ID
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(FlightReadDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<FlightReadDto>> Update(int id, [FromBody] FlightCreateDto dto)
    {
        try
        {
            var updated = await _service.UpdateFlightAsync(id, dto);

            if (updated == null)
                return NotFound();

            return Ok(updated);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Delete flight by ID
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteFlightAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}