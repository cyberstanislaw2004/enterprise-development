using Airlines.Application.Services;
using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketController : Controller
{
    private readonly TicketService _service;
    private readonly IRepository<Flight> _flightRepository;
    private readonly IRepository<Passenger> _passengerRepository;

    public TicketController(
        TicketService service,
        IRepository<Flight> flightRepository,
        IRepository<Passenger> passengerRepository)
    {
        _service = service;
        _flightRepository = flightRepository;
        _passengerRepository = passengerRepository;
    }

    [HttpGet]
    public IActionResult GetAll() =>
        Ok(_service.GetTickets());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var entity = _service.GetTicket(id);
        if (entity == null) return NotFound();
        return Ok(entity);
    }

    [HttpPost]
    public IActionResult Create([FromBody] TicketCreateDto dto)
    {
        var flight = _flightRepository.Read(dto.FlightId);
        if (flight == null) return BadRequest("Invalid Flight ID");

        var passenger = _passengerRepository.Read(dto.PassengerId);
        if (passenger == null) return BadRequest("Invalid Passenger ID");

        var id = _service.CreateTicket(dto, flight, passenger);
        return CreatedAtAction(nameof(Get), new { id }, dto);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] TicketCreateDto dto)
    {
        var flight = _flightRepository.Read(dto.FlightId);
        if (flight == null) return BadRequest("Invalid Flight ID");

        var passenger = _passengerRepository.Read(dto.PassengerId);
        if (passenger == null) return BadRequest("Invalid Passenger ID");

        var updated = _service.UpdateTicket(id, dto, flight, passenger);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.DeleteTicket(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}