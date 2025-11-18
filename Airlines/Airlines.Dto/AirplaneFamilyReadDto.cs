namespace Airlines.Dto;

/// <summary>
/// DTO for read
/// </summary>
public record AirplaneFamilyReadDto
{
    /// <summary>
    /// Unique ID for the primary key in the database
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Family name
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Manufacturer name
    /// </summary>
    public string Manufacturer { get; init; }

    /// <summary>
    /// DTO for read constructor
    /// </summary>
    public AirplaneFamilyReadDto(int Id, string Name, string Manufacturer)
    {
        this.Id = Id;
        this.Name = Name;
        this.Manufacturer = Manufacturer;
    }
}