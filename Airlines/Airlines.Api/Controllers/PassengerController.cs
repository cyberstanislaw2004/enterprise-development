using Airlines.Application.Interfaces;
using Airlines.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Api.Controllers;

/// <summary>
/// Controller for managing passengers
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class PassengerController(IPassengerService _service, ITicketService _ticketService) : ControllerBase
{
    /// <summary>
    /// Returns a list of all passengers
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<PassengerReadDto>), 200)]
    public async Task<ActionResult<List<PassengerReadDto>>> GetAll()
    {
        var passengers = await _service.GetPassengersAsync();
        return Ok(passengers);
    }

    /// <summary>
    /// Returns information about passenger by id
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PassengerReadDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<PassengerReadDto>> Get(int id)
    {
        var passenger = await _service.GetPassengerAsync(id);

        if (passenger == null)
            return NotFound();

        return Ok(passenger);
    }

    /// <summary>
    /// Returns all tickets for this passenger
    /// </summary>
    [HttpGet("{id}/tickets")]
    [ProducesResponseType(typeof(List<TicketReadDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<List<TicketReadDto>>> GetTickets(int id)
    {
        var passenger = await _service.GetPassengerAsync(id);
        if (passenger == null)
            return NotFound();

        var tickets = (await _ticketService.GetTicketsAsync())
            .Where(t => t.PassengerInfo.Id == id)
            .ToList();

        return Ok(tickets);
    }

    /// <summary>
    /// Create a new passenger
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(PassengerReadDto), 201)]
    public async Task<ActionResult<PassengerReadDto>> Create([FromBody] PassengerCreateDto dto)
    {
        var created = await _service.CreatePassengerAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    /// <summary>
    /// Update passenger by ID
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(PassengerReadDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<PassengerReadDto>> Update(int id, [FromBody] PassengerCreateDto dto)
    {
        var updated = await _service.UpdatePassengerAsync(id, dto);

        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

    /// <summary>
    /// Delete passenger by ID
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _service.DeletePassengerAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}