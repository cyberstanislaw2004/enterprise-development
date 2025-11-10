namespace Airlines.Dto;

public record AirplaneFamilyCreateDto(
    string Name,
    string Manufacturer
);

public record AirplaneFamilyReadDto(
    int Id,
    string Name,
    string Manufacturer
);