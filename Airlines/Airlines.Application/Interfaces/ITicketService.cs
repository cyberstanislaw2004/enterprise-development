using Airlines.Dto;

namespace Airlines.Application.Interfaces;

/// <summary>
/// Interface for managing passengers entities
/// </summary>
public interface ITicketService
{
    /// <summary>
    /// Get all tickets
    /// </summary>
    public Task<List<TicketReadDto>> GetTicketsAsync();

    /// <summary>
    /// Get ticket by ID
    /// </summary>
    public Task<TicketReadDto?> GetTicketAsync(int id);

    /// <summary>
    /// Create a new ticket record
    /// </summary>
    public Task<TicketReadDto> CreateTicketAsync(TicketCreateDto dto);

    /// <summary>
    /// Update ticket by ID
    /// </summary>
    public Task<TicketReadDto?> UpdateTicketAsync(int id, TicketCreateDto dto);

    /// <summary>
    /// Delete ticket by ID
    /// </summary>
    public Task<bool> DeleteTicketAsync(int id);
}