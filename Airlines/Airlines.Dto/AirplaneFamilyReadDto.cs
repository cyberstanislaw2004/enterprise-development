namespace Airlines.Dto;

/// <summary>
/// DTO for read
/// </summary>
public record AirplaneFamilyReadDto(
    int Id,
    string Name,
    string Manufacturer
);