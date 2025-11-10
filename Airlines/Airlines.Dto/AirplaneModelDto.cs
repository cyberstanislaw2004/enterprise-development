namespace Airlines.Dto;

/// <summary>
/// DTO for create
/// </summary>
public record AirplaneModelCreateDto(
    string ModelName,
    int? FamilyId,
    AirplaneFamilyCreateDto AirplaneFamily,
    double RangeOfFlight,
    int PassengerCapacity,
    double CargoCapacity
);

/// <summary>
/// DTO for read
/// </summary>
public record AirplaneModelReadDto(
    int Id,
    string ModelName,
    AirplaneFamilyReadDto AirplaneFamily,
    double RangeOfFlight,
    int PassengerCapacity,
    double CargoCapacity
);