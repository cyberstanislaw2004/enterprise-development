using Airlines.Dto;
using Airlines.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AirplaneFamilyController : ControllerBase
{
    private readonly AirplaneFamilyService _service;

    public AirplaneFamilyController(AirplaneFamilyService service) =>
        _service = service;

    [HttpGet]
    public IActionResult GetAll() =>
        Ok(_service.GetAirplaneFamilies());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var entity = _service.GetAirplaneFamily(id);
        if (entity == null) return NotFound();
        return Ok(entity);
    }

    [HttpPost]
    public IActionResult Create([FromBody] AirplaneFamilyCreateDto dto)
    {
        var id = _service.CreateAirplaneFamily(dto);
        return CreatedAtAction(nameof(Get), new { id }, dto);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] AirplaneFamilyCreateDto dto)
    {
        var updated = _service.UpdateAirplaneFamily(id, dto);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.DeleteAirplaneFamily(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}