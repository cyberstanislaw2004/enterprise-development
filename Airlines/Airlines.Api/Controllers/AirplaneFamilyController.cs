using Airlines.Application.Interfaces;
using Airlines.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Api.Controllers;

/// <summary>
/// Controller for managing aircraft families
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AirplaneFamilyController(IAirplaneFamilyService _service, IAirplaneModelService _modelService) : ControllerBase
{
    /// <summary>
    /// Returns a list of all airplane families
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<AirplaneFamilyReadDto>), 200)]
    public async Task<ActionResult<List<AirplaneFamilyReadDto>>> GetAll()
    {
        var families = await _service.GetAirplaneFamiliesAsync();
        return Ok(families);
    }

    /// <summary>
    /// Returns information about airplane family by id
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(AirplaneFamilyReadDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<AirplaneFamilyReadDto>> Get(int id)
    {
        var entity = await _service.GetAirplaneFamilyAsync(id);
        if (entity == null)
            return NotFound();

        return Ok(entity);
    }

    /// <summary>
    /// Returns airplane models for family
    /// </summary>
    [HttpGet("{id}/models")]
    [ProducesResponseType(typeof(List<AirplaneModelReadDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<List<AirplaneModelReadDto>>> GetModels(int id)
    {
        var family = await _service.GetAirplaneFamilyAsync(id);
        if (family == null)
            return NotFound();

        var models = await _modelService.GetAirplaneModelsByFamilyIdAsync(id);
        return Ok(models);
    }

    /// <summary>
    /// Create a new airplane family
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(AirplaneFamilyReadDto), 201)]
    public async Task<ActionResult<AirplaneFamilyReadDto>> Create([FromBody] AirplaneFamilyCreateDto dto)
    {
        var created = await _service.CreateAirplaneFamilyAsync(dto);

        return CreatedAtAction(
            nameof(Get),
            new { id = created.Id },
            created
        );
    }

    /// <summary>
    /// Update airplane family by ID
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(AirplaneFamilyReadDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<AirplaneFamilyReadDto>> Update(int id, [FromBody] AirplaneFamilyCreateDto dto)
    {
        var updated = await _service.UpdateAirplaneFamilyAsync(id, dto);
        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

    /// <summary>
    /// Delete airplane family by ID
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAirplaneFamilyAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}