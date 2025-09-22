namespace Airlines.Domain;

/// <summary>
/// Passenger class
/// </summary>
public class Passenger
{
    /// <summary>
    /// Unique ID for the primary key in the database
    /// </summary>
    public required int Id { get; set; }

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
