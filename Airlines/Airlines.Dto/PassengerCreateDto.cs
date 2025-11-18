namespace Airlines.Dto;

/// <summary>
/// DTO for create
/// </summary>
public record PassengerCreateDto(
    string NumberOfPassport,
    string FullName,
    DateOnly? BirthDate
);