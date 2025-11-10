using Airlines.Dto;
using Airlines.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PassengerController : ControllerBase
{
    private readonly PassengerService _service;

    public PassengerController(PassengerService service) =>
        _service = service;

    [HttpGet]
    public IActionResult GetAll() =>
        Ok(_service.GetPassengers());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var entity = _service.GetPassenger(id);
        if (entity == null)
            return NotFound();
        return Ok(entity);
    }

    [HttpPost]
    public IActionResult Create([FromBody] PassengerCreateDto dto)
    {
        var id = _service.CreatePassenger(dto);
        return CreatedAtAction(nameof(Get), new { id }, dto);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] PassengerCreateDto dto)
    {
        var updated = _service.UpdatePassenger(id, dto);
        if (updated == null)
            return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.DeletePassenger(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}