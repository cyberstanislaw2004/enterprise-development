namespace Airlines.Dto;

/// <summary>
/// DTO for create
/// </summary>
public record AirplaneFamilyCreateDto(
    string Name,
    string Manufacturer
);

/// <summary>
/// DTO for read
/// </summary>
public record AirplaneFamilyReadDto(
    int Id,
    string Name,
    string Manufacturer
);