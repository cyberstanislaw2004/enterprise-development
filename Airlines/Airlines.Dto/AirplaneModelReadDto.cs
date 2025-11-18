namespace Airlines.Dto;

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