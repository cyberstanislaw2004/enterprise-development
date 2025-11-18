namespace Airlines.Dto;

/// <summary>
/// DTO for create
/// </summary>
public record AirplaneModelCreateDto
{
    /// <summary>
    /// Aircraft model name
    /// </summary>
    public string ModelName { get; init; }

    /// <summary>
    /// Associated family ID
    /// </summary>
    public int? FamilyId { get; init; }

    /// <summary>
    /// Flight range in km
    /// </summary>
    public double RangeOfFlight { get; init; }

    /// <summary>
    /// Passenger capacity
    /// </summary>
    public int PassengerCapacity { get; init; }

    /// <summary>
    /// Cargo capacity in tons
    /// </summary>
    public double CargoCapacity { get; init; }

    /// <summary>
    /// Create DTO constructor
    /// </summary>
    public AirplaneModelCreateDto(string modelName, int? familyId, double rangeOfFlight, int passengerCapacity, double cargoCapacity)
    {
        ModelName = modelName;
        FamilyId = familyId;
        RangeOfFlight = rangeOfFlight;
        PassengerCapacity = passengerCapacity;
        CargoCapacity = cargoCapacity;
    }
}