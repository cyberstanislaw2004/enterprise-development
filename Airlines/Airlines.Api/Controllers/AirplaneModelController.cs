using Airlines.Application.Services;
using Airlines.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Api.Controllers;

/// <summary>
/// Controller for managing aircraft models
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AirplaneModelController(AirplaneModelService _service, FlightService _flightService) : ControllerBase
{
    /// <summary>
    /// Returns a list of all airplane models
    /// </summary>
    [HttpGet]
    [ProducesResponseType(200)]
    public ActionResult GetAll() =>
        Ok(_service.GetAirplaneModels());

    /// <summary>
    /// Returns information about airplane model by id
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult Get(int id)
    {
        var entity = _service.GetAirplaneModel(id);
        if (entity == null) return NotFound();
        return Ok(entity);
    }

    /// <summary>
    /// Returns all flights for this airplane model
    /// </summary>
    [HttpGet("{id}/flights")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult GetFlights(int id)
    {
        var model = _service.GetAirplaneModel(id);
        if (model == null) return NotFound();

        var flights = _flightService
            .GetFlights()
            .Where(f => f.AirplaneModel.Id == id)
            .ToList();

        return Ok(flights);
    }

    /// <summary>
    /// Create a new airplane model
    /// </summary>
    [HttpPost]
    [ProducesResponseType(201)]
    public ActionResult Create([FromBody] AirplaneModelCreateDto dto)
    {
        try
        {
            var id = _service.CreateAirplaneModel(dto);
            return CreatedAtAction(nameof(Get), new { id }, dto);
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
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult Update(int id, [FromBody] AirplaneModelCreateDto dto)
    {
        try
        {
            var updated = _service.UpdateAirplaneModel(id, dto);
            if (updated == null) return NotFound();
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
    public ActionResult Delete(int id)
    {
        _service.DeleteAirplaneModel(id);
        return NoContent();
    }
}