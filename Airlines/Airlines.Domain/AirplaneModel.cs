namespace Airlines.Domain;

/// <summary>
/// A class that stores information about an aircraft model
/// </summary>
public class AirplaneModel
{
    /// <summary>
    /// Unique ID for the primary key in the database
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Aircraft model name
    /// </summary>
    public required string ModelName { get; set; }

    /// <summary>
    /// Model family
    /// </summary>
    public required AirplaneFamily AirplaneFamily { get; set; }

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