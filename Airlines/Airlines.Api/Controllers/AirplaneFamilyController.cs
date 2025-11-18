using Airlines.Dto;
using Airlines.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Api.Controllers;

/// <summary>
/// Controller for managing aircraft families
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AirplaneFamilyController : ControllerBase
{
    private readonly AirplaneFamilyService _service;
    private readonly AirplaneModelService _modelService;

    /// <summary>
    /// Initializes the controller
    /// </summary>
    public AirplaneFamilyController(AirplaneFamilyService service, AirplaneModelService modelService)
    {
        _service = service;
        _modelService = modelService;
    }

    /// <summary>
    /// Returns a list of all airplane families
    /// </summary>
    [HttpGet]
    public IActionResult GetAll() =>
        Ok(_service.GetAirplaneFamilies());

    /// <summary>
    /// Returns information about airplane family by id
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var entity = _service.GetAirplaneFamily(id);
        if (entity == null) return NotFound();
        return Ok(entity);
    }

    /// <summary>
    /// Returns airplane models for family
    /// </summary>
    [HttpGet("{id}/models")]
    public IActionResult GetModels(int id)
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
    public IActionResult Create([FromBody] AirplaneFamilyCreateDto dto)
    {
        var id = _service.CreateAirplaneFamily(dto);
        return CreatedAtAction(nameof(Get), new { id }, dto);
    }

    /// <summary>
    /// Update airplane family by ID
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] AirplaneFamilyCreateDto dto)
    {
        var updated = _service.UpdateAirplaneFamily(id, dto);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    /// <summary>
    /// Delete airplane family by ID
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.DeleteAirplaneFamily(id);
        return NoContent();
    }
}