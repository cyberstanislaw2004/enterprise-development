using Airlines.Dto;

namespace Airlines.Application.Interfaces;

/// <summary>
/// Interface for managing passengers entities
/// </summary>
public interface IPassengerService
{
    /// <summary>
    /// Get all passengers
    /// </summary>
    public Task<List<PassengerReadDto>> GetPassengersAsync();

    /// <summary>
    /// Get passenger by ID
    /// </summary>
    public Task<PassengerReadDto?> GetPassengerAsync(int id);

    /// <summary>
    /// Create a new passenger record
    /// </summary>
    public Task<PassengerReadDto> CreatePassengerAsync(PassengerCreateDto dto);

    /// <summary>
    /// Update passenger by ID
    /// </summary>
    public Task<PassengerReadDto?> UpdatePassengerAsync(int id, PassengerCreateDto dto);

    /// <summary>
    /// Delete passenger by ID
    /// </summary>
    public Task<bool> DeletePassengerAsync(int id);
}