namespace Airlines.Dto;

/// <summary>
/// DTO for create
/// </summary>
public record AirplaneFamilyCreateDto(
    string Name,
    string Manufacturer
);