namespace Airlines.Dto;

/// <summary>
/// DTO for create
/// </summary>
public record AirplaneFamilyCreateDto
{
    /// <summary>
    /// Family name
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Manufacturer name
    /// </summary>
    public string Manufacturer { get; init; }

    /// <summary>
    /// Create DTO constructor
    /// </summary>
    public AirplaneFamilyCreateDto(string Name, string Manufacturer)
    {
        this.Name = Name;
        this.Manufacturer = Manufacturer;
    }
}