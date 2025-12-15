using Airlines.Dto;

namespace Airlines.Application.Interfaces;

/// <summary>
/// Interface for managing flights entities
/// </summary>
public interface IFlightService
{
    /// <summary>
    /// Get all flights
    /// </summary>
    public Task<List<FlightReadDto>> GetFlightsAsync();

    /// <summary>
    /// Get flight by ID
    /// </summary>
    public Task<FlightReadDto?> GetFlightAsync(int id);

    /// <summary>
    /// Get all flights for a specific airplane model
    /// </summary>
    public Task<List<FlightReadDto>> GetFlightsByAirplaneModelIdAsync(int airplaneModelId);

    /// <summary>
    /// Create a new flight record
    /// </summary>
    public Task<FlightReadDto> CreateFlightAsync(FlightCreateDto dto);

    /// <summary>
    /// Update flight by ID
    /// </summary>
    public Task<FlightReadDto?> UpdateFlightAsync(int id, FlightCreateDto dto);

    /// <summary>
    /// Delete flight by ID
    /// </summary>
    public Task<bool> DeleteFlightAsync(int id);
}