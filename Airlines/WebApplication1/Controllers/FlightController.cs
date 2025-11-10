using Airlines.Application.Services;
using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlightController : ControllerBase
{
    private readonly FlightService _service;
    private readonly IRepository<AirplaneModel> _modelRepository;

    public FlightController(
        FlightService service,
        IRepository<AirplaneModel> modelRepository)
    {
        _service = service;
        _modelRepository = modelRepository;
    }

    [HttpGet]
    public IActionResult GetAll() =>
        Ok(_service.GetFlights());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var entity = _service.GetFlight(id);
        if (entity == null) return NotFound();
        return Ok(entity);
    }

    [HttpPost]
    public IActionResult Create([FromBody] FlightCreateDto dto)
    {
        var model = _modelRepository.Read(dto.AirplaneModelId);
        if (model == null)
            return BadRequest("Invalid AirplaneModel ID");

        var id = _service.CreateFlight(dto, model);
        return CreatedAtAction(nameof(Get), new { id }, dto);
    }

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

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.DeleteFlight(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
