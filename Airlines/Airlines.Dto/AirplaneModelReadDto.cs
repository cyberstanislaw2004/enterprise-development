namespace Airlines.Dto;

/// <summary>
/// DTO for read
/// </summary>
public record AirplaneModelReadDto
{
    /// <summary>
    /// Unique ID for the primary key in the database
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Aircraft model name
    /// </summary>
    public string ModelName { get; init; }

    /// <summary>
    /// Associated airplane family
    /// </summary>
    public AirplaneFamilyReadDto AirplaneFamily { get; init; }

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
    /// DTO for read constructor
    /// </summary>
    public AirplaneModelReadDto(int id, string modelName, AirplaneFamilyReadDto airplaneFamily, double rangeOfFlight, int passengerCapacity, double cargoCapacity)
    {
        Id = id;
        ModelName = modelName;
        AirplaneFamily = airplaneFamily;
        RangeOfFlight = rangeOfFlight;
        PassengerCapacity = passengerCapacity;
        CargoCapacity = cargoCapacity;
    }
}