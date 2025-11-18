using Airlines.Dto;
using Airlines.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Api.Controllers;

/// <summary>
/// Controller for managing passengers
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class PassengerController : ControllerBase
{
    private readonly PassengerService _service;

    /// <summary>
    /// Initializes the controller
    /// </summary>
    public PassengerController(PassengerService service) =>
        _service = service;

    /// <summary>
    /// Returns a list of all passengers
    /// </summary>
    [HttpGet]
    public IActionResult GetAll() =>
        Ok(_service.GetPassengers());

    /// <summary>
    /// Returns information about passenger by id
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var entity = _service.GetPassenger(id);
        if (entity == null)
            return NotFound();
        return Ok(entity);
    }

    /// <summary>
    /// Create a new passenger
    /// </summary>
    [HttpPost]
    public IActionResult Create([FromBody] PassengerCreateDto dto)
    {
        var id = _service.CreatePassenger(dto);
        return CreatedAtAction(nameof(Get), new { id }, dto);
    }

    /// <summary>
    /// Update passenger by ID
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] PassengerCreateDto dto)
    {
        var updated = _service.UpdatePassenger(id, dto);
        if (updated == null)
            return NotFound();
        return Ok(updated);
    }

    /// <summary>
    /// Delete passenger by ID
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.DeletePassenger(id);
        return NoContent();
    }
}