using Airlines.Dto;

namespace Airlines.Application.Interfaces;

/// <summary>
/// Interface for managing airplane models entities
/// </summary>
public interface IAirplaneModelService
{
    /// <summary>
    /// Get all airplane models
    /// </summary>
    public Task<List<AirplaneModelReadDto>> GetAirplaneModelsAsync();

    /// <summary>
    /// Get airplane model by ID
    /// </summary>
    public Task<AirplaneModelReadDto?> GetAirplaneModelAsync(int id);

    /// <summary>
    /// Get airplane models by family ID
    /// </summary>
    public Task<List<AirplaneModelReadDto>> GetAirplaneModelsByFamilyIdAsync(int familyId);

    /// <summary>
    /// Create a new airplane model record
    /// </summary>
    public Task<AirplaneModelReadDto> CreateAirplaneModelAsync(AirplaneModelCreateDto dto);

    /// <summary>
    /// Update airplane model by ID
    /// </summary>
    public Task<AirplaneModelReadDto?> UpdateAirplaneModelAsync(int id, AirplaneModelCreateDto dto);

    /// <summary>
    /// Delete airplane model by ID
    /// </summary>
    public Task<bool> DeleteAirplaneModelAsync(int id);
}