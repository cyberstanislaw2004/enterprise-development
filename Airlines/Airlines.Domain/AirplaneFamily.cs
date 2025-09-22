namespace Airlines.Domain;

/// <summary>
/// Class describing a family of aircraft
/// </summary>
public class AirplaneFamily
{
    /// <summary>
    /// Unique ID for the primary key in the database
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Family name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Manufacturer name
    /// </summary>
    public required string Manufacturer { get; set; }
}
