using Airlines.Application.Services;
using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Api.Controllers;

/// <summary>
/// Controller for managing flights
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class FlightController : ControllerBase
{
    private readonly FlightService _service;
    private readonly IRepository<AirplaneModel> _modelRepository;

    /// <summary>
    /// Initializes the controller
    /// </summary>
    public FlightController(
        FlightService service,
        IRepository<AirplaneModel> modelRepository)
    {
        _service = service;
        _modelRepository = modelRepository;
    }

    /// <summary>
    /// Returns a list of all flights
    /// </summary>
    [HttpGet]
    public IActionResult GetAll() =>
        Ok(_service.GetFlights());

    /// <summary>
    /// Returns information about flight by id
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var entity = _service.GetFlight(id);
        if (entity == null) return NotFound();
        return Ok(entity);
    }

    /// <summary>
    /// Create a new flight
    /// </summary>
    [HttpPost]
    public IActionResult Create([FromBody] FlightCreateDto dto)
    {
        var model = _modelRepository.Read(dto.AirplaneModelId);
        if (model == null)
            return BadRequest("Invalid AirplaneModel ID");

        var id = _service.CreateFlight(dto, model);
        return CreatedAtAction(nameof(Get), new { id }, dto);
    }

    /// <summary>
    /// Update flight by ID
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] FlightCreateDto dto)
    {
        var model = _modelRepository.Read(dto.AirplaneModelId);
        if (model == null)
            return BadRequest("Invalid AirplaneModel ID");

        var updated = _service.UpdateFlight(id, dto, model);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    /// <summary>
    /// Delete flight by ID
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.DeleteFlight(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}