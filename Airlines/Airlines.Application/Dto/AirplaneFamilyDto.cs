namespace Airlines.Application.Dto;

/// <summary>
/// Class describing a family of aircraft
/// </summary>
public class AirplaneFamilyDto
{
    /// <summary>
    /// Family name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Manufacturer name
    /// </summary>
    public required string Manufacturer { get; set; }
}
