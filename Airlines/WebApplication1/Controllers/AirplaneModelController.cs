using Airlines.Application.Services;
using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Api.Controllers;

/// <summary>
/// Controller for managing aircraft models
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AirplaneModelController : ControllerBase
{
    private readonly AirplaneModelService _service;
    private readonly IRepository<AirplaneFamily> _familyRepository;

    /// <summary>
    /// Initializes the controller
    /// </summary>
    public AirplaneModelController(
        AirplaneModelService service,
        IRepository<AirplaneFamily> familyRepository)
    {
        _service = service;
        _familyRepository = familyRepository;
    }

    /// <summary>
    /// Returns a list of all airplane models
    /// </summary>
    [HttpGet]
    public IActionResult GetAll() =>
        Ok(_service.GetAirplaneModels());

    /// <summary>
    /// Returns information about airplane model by id
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var entity = _service.GetAirplaneModel(id);
        if (entity == null) return NotFound();
        return Ok(entity);
    }

    /// <summary>
    /// Create a new airplane model
    /// </summary>
    [HttpPost]
    public IActionResult Create([FromBody] AirplaneModelCreateDto dto)
    {
        AirplaneFamily family;

        if (dto.FamilyId.HasValue)
        {
            family = _familyRepository.Read(dto.FamilyId.Value);
            if (family == null)
                return BadRequest("Invalid AirplaneFamily ID");
        }
        else if (dto.AirplaneFamily != null)
        {
            family = new AirplaneFamily
            {
                Id = 0,
                Name = dto.AirplaneFamily.Name,
                Manufacturer = dto.AirplaneFamily.Manufacturer
            };
        }
        else
        {
            return BadRequest("You must specify FamilyId or AirplaneFamily");
        }

        var id = _service.CreateAirplaneModel(dto, family);
        return CreatedAtAction(nameof(Get), new { id }, dto);
    }

    /// <summary>
    /// Update airplane model by ID
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] AirplaneModelCreateDto dto)
    {
        AirplaneFamily family;

        if (dto.FamilyId.HasValue)
        {
            family = _familyRepository.Read(dto.FamilyId.Value);
            if (family == null)
                return BadRequest("Invalid AirplaneFamily ID");
        }
        else if (dto.AirplaneFamily != null)
        {
            family = new AirplaneFamily
            {
                Id = 0,
                Name = dto.AirplaneFamily.Name,
                Manufacturer = dto.AirplaneFamily.Manufacturer
            };
        }
        else
        {
            return BadRequest("You must specify FamilyId or AirplaneFamily");
        }

        var updated = _service.UpdateAirplaneModel(id, dto, family);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    /// <summary>
    /// Delete airplane model by ID
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.DeleteAirplaneModel(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}