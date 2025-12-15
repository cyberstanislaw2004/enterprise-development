using Airlines.Dto;

namespace Airlines.Application.Interfaces;

/// <summary>
/// Interface for managing airplane family entities
/// </summary>
public interface IAirplaneFamilyService
{
    /// <summary>
    /// Get all airplane families
    /// </summary>
    public Task<List<AirplaneFamilyReadDto>> GetAirplaneFamiliesAsync();

    /// <summary>
    /// Get airplane family by ID
    /// </summary>
    public Task<AirplaneFamilyReadDto?> GetAirplaneFamilyAsync(int id);

    /// <summary>
    /// Create a new airplane family record
    /// </summary>
    public Task<AirplaneFamilyReadDto> CreateAirplaneFamilyAsync(AirplaneFamilyCreateDto dto);

    /// <summary>
    /// Update airplane family by ID
    /// </summary>
    public Task<AirplaneFamilyReadDto?> UpdateAirplaneFamilyAsync(int id, AirplaneFamilyCreateDto dto);

    /// <summary>
    /// Delete airplane family by ID
    /// </summary>
    public Task<bool> DeleteAirplaneFamilyAsync(int id);
}