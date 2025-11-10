namespace Airlines.Dto;

public record PassengerCreateDto(
    string NumberOfPassport,
    string FullName,
    DateOnly? BirthDate
);

public record PassengerReadDto(
    int Id,
    string NumberOfPassport,
    string FullName,
    DateOnly? BirthDate
);