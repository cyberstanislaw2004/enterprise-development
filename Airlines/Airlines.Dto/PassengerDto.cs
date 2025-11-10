namespace Airlines.Dto;

/// <summary>
/// DTO for create
/// </summary>
public record PassengerCreateDto(
    string NumberOfPassport,
    string FullName,
    DateOnly? BirthDate
);

/// <summary>
/// DTO for read
/// </summary>
public record PassengerReadDto(
    int Id,
    string NumberOfPassport,
    string FullName,
    DateOnly? BirthDate
);