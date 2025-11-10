namespace Airlines.Dto;

public record AirplaneModelCreateDto(
    string ModelName,
    int? FamilyId,
    AirplaneFamilyCreateDto AirplaneFamily,
    double RangeOfFlight,
    int PassengerCapacity,
    double CargoCapacity
);

public record AirplaneModelReadDto(
    int Id,
    string ModelName,
    AirplaneFamilyReadDto AirplaneFamily,
    double RangeOfFlight,
    int PassengerCapacity,
    double CargoCapacity
);