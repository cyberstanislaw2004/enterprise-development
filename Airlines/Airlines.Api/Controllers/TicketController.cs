using Airlines.Application.Interfaces;
using Airlines.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Api.Controllers;

/// <summary>
/// Controller for managing tickets
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TicketController(ITicketService _service) : ControllerBase
{
    /// <summary>
    /// Returns a list of all tickets
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<TicketReadDto>), 200)]
    public async Task<ActionResult<List<TicketReadDto>>> GetAll()
    {
        var tickets = await _service.GetTicketsAsync();
        return Ok(tickets);
    }

    /// <summary>
    /// Returns information about ticket by id
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TicketReadDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<TicketReadDto>> Get(int id)
    {
        var ticket = await _service.GetTicketAsync(id);
        if (ticket == null) return NotFound();
        return Ok(ticket);
    }

    /// <summary>
    /// Create a new ticket
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(TicketReadDto), 201)]
    public async Task<ActionResult<TicketReadDto>> Create([FromBody] TicketCreateDto dto)
    {
        try
        {
            var ticket = await _service.CreateTicketAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = ticket.Id }, ticket);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Update ticket by ID
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(TicketReadDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<TicketReadDto>> Update(int id, [FromBody] TicketCreateDto dto)
    {
        try
        {
            var updated = await _service.UpdateTicketAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Delete ticket by ID
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteTicketAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}