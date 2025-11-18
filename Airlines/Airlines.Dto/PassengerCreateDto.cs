namespace Airlines.Dto;

/// <summary>
/// DTO for create
/// </summary>
public record PassengerCreateDto
{
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
    /// Create DTO constructor
    /// </summary>
    public PassengerCreateDto(string numberOfPassport, string fullName, DateOnly? birthDate)
    {
        NumberOfPassport = numberOfPassport;
        FullName = fullName;
        BirthDate = birthDate;
    }
}