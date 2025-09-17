namespace Airlines.Domain;

/// <summary>
/// Class describing a family of aircraft
/// </summary>
public class AirplaneFamily
{
    /// <summary>
    /// Family name
    /// </summary>
    public required string NameOfFamily { get; set; }

    /// <summary>
    /// Manufacturer name
    /// </summary>
    public required string NameOfManufacturer { get; set; }
}
