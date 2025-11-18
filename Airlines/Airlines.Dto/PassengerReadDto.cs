namespace Airlines.Dto;

/// <summary>
/// DTO for read
/// </summary>
public record PassengerReadDto
{
    /// <summary>
    /// Unique ID for the primary key in the database
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Passport number
    /// </summary>
    public string NumberOfPassport { get; init; }

    /// <summary>
    /// Full name
    /// </summary>
    public string FullName { get; init; }

    /// <summary>
    /// Date of birth
    /// </summary>
    public DateOnly? BirthDate { get; init; }

    /// <summary>
    /// DTO for read constructor
    /// </summary>
    public PassengerReadDto(int id, string numberOfPassport, string fullName, DateOnly? birthDate)
    {
        Id = id;
        NumberOfPassport = numberOfPassport;
        FullName = fullName;
        BirthDate = birthDate;
    }
}