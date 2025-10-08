namespace Airlines.Application.Dto;

/// <summary>
/// Passenger class
/// </summary>
public class PassengerDto
{
    /// <summary>
    /// Passport number
    /// </summary>
    public required string NumberOfPassport { get; set; }

    /// <summary>
    /// Full name
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Date of birth
    /// </summary>
    public DateOnly? BirthDate { get; set; }
}
