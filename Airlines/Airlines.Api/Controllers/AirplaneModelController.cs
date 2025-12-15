using Airlines.Application.Interfaces;
using Airlines.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Api.Controllers;

/// <summary>
/// Controller for managing aircraft models
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AirplaneModelController(IAirplaneModelService _service, IFlightService _flightService) : ControllerBase
{
    /// <summary>
    /// Returns a list of all airplane models
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<AirplaneModelReadDto>), 200)]
    public async Task<ActionResult<List<AirplaneModelReadDto>>> GetAll()
    {
        var models = await _service.GetAirplaneModelsAsync();
        return Ok(models);
    }


    /// <summary>
    /// Returns information about airplane model by id
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(List<AirplaneModelReadDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<AirplaneModelReadDto>> Get(int id)
    {
        var entity = await _service.GetAirplaneModelAsync(id);
        if (entity == null)
            return NotFound();

        return Ok(entity);
    }

    /// <summary>
    /// Returns all flights for this airplane model
    /// </summary>
    [HttpGet("{id}/flights")]
    [ProducesResponseType(typeof(List<FlightReadDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<List<FlightReadDto>>> GetFlights(int id)
    {
        var model = await _service.GetAirplaneModelAsync(id);
        if (model == null)
            return NotFound();

        var flights = await _flightService.GetFlightsByAirplaneModelIdAsync(id);
        return Ok(flights);
    }

    /// <summary>
    /// Create a new airplane model
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(AirplaneModelReadDto), 201)]
    public async Task<ActionResult<AirplaneModelReadDto>> Create([FromBody] AirplaneModelCreateDto dto)
    {
        try
        {
            var created = await _service.CreateAirplaneModelAsync(dto);

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
    /// Update airplane model by ID
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(AirplaneModelReadDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<AirplaneModelReadDto>> Update(int id, [FromBody] AirplaneModelCreateDto dto)
    {
        try
        {
            var updated = await _service.UpdateAirplaneModelAsync(id, dto);
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
    /// Delete airplane model by ID
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAirplaneModelAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}