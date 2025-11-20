using Airlines.Application.Services;
using Airlines.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Api.Controllers;

/// <summary>
/// Controller for managing aircraft families
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AirplaneFamilyController(AirplaneFamilyService _service, AirplaneModelService _modelService) : ControllerBase
{
    /// <summary>
    /// Returns a list of all airplane families
    /// </summary>
    [HttpGet]
    [ProducesResponseType(200)]
    public ActionResult GetAll() =>
        Ok(_service.GetAirplaneFamilies());

    /// <summary>
    /// Returns information about airplane family by id
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult Get(int id)
    {
        var entity = _service.GetAirplaneFamily(id);
        if (entity == null) return NotFound();
        return Ok(entity);
    }

    /// <summary>
    /// Returns airplane models for family
    /// </summary>
    [HttpGet("{id}/models")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult GetModels(int id)
    {
        var family = _service.GetAirplaneFamily(id);
        if (family == null) return NotFound();

        var models = _modelService
            .GetAirplaneModels()
            .Where(m => m.AirplaneFamily.Id == id)
            .ToList();

        return Ok(models);
    }

    /// <summary>
    /// Create a new airplane family
    /// </summary>
    [HttpPost]
    [ProducesResponseType(201)]
    public ActionResult Create([FromBody] AirplaneFamilyCreateDto dto)
    {
        var id = _service.CreateAirplaneFamily(dto);
        return CreatedAtAction(nameof(Get), new { id }, dto);
    }

    /// <summary>
    /// Update airplane family by ID
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult Update(int id, [FromBody] AirplaneFamilyCreateDto dto)
    {
        var updated = _service.UpdateAirplaneFamily(id, dto);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    /// <summary>
    /// Delete airplane family by ID
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public ActionResult Delete(int id)
    {
        _service.DeleteAirplaneFamily(id);
        return NoContent();
    }
}