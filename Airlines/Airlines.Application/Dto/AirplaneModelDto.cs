namespace Airlines.Application.Dto;

/// <summary>
/// A class that stores information about an aircraft model
/// </summary>
public class AirplaneModelDto
{
    /// <summary>
    /// Aircraft model name
    /// </summary>
    public required string ModelName { get; set; }

    /// <summary>
    /// Model family
    /// </summary>
    public required AirplaneFamilyDto AirplaneFamily { get; set; }

    /// <summary>
    /// Flight range in km
    /// </summary>
    public required double RangeOfFlight { get; set; }

    /// <summary>
    /// Passenger capacity
    /// </summary>
    public required int PassengerCapacity { get; set; }

    /// <summary>
    /// Cargo capacity in tons
    /// </summary>
    public required double CargoCapacity { get; set; }
}
