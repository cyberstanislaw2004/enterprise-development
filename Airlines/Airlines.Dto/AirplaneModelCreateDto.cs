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