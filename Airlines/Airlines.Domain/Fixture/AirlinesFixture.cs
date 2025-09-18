using Airlines.Domain;

namespace Airlines.Domain.Fixture;

public class AirlinesFixture
{
    public List<AirplaneFamily> AirplaneFamilies =>
    [
        new()
        {
            NameOfFamily = "A320",
            NameOfManufacturer = "Airbus"
        },
        new()
        {
            NameOfFamily = "B737",
            NameOfManufacturer = "Boeing"
        },
        new()
        {
            NameOfFamily = "SSJ",
            NameOfManufacturer = "Sukhoi"
        },
        new()
        {
            NameOfFamily = "MC-21",
            NameOfManufacturer = "Irkut"
        },
        new()
        {
            NameOfFamily = "E190",
            NameOfManufacturer = "Embraer"
        },
        new()
        {
            NameOfFamily = "CRJ",
            NameOfManufacturer = "Bombardier"
        },
        new()
        {
            NameOfFamily = "Tu-204",
            NameOfManufacturer = "Tupolev"
        },
        new()
        {
            NameOfFamily = "Il-96",
            NameOfManufacturer = "Ilyushin"
        },
        new()
        {
            NameOfFamily = "A350",
            NameOfManufacturer = "Airbus"
        },
        new()
        {
            NameOfFamily = "B777",
            NameOfManufacturer = "Boeing"
        }
    ];

    public List<AirplaneModel> AirplaneModels =>
    [
        new()
        {
            Id = 1,
            ModelName = "A320-200",
            AirplaneFamily = AirplaneFamilies[0],
            RangeOfFlight = 6100,
            PassengerCapacity = 180,
            CargoCapacity = 20
        },
        new()
        {
            Id = 2,
            ModelName = "737-800",
            AirplaneFamily = AirplaneFamilies[1],
            RangeOfFlight = 5436,
            PassengerCapacity = 189,
            CargoCapacity = 18
        },
        new()
        {
            Id = 3,
            ModelName = "SSJ100",
            AirplaneFamily = AirplaneFamilies[2],
            RangeOfFlight = 4500,
            PassengerCapacity = 108,
            CargoCapacity = 12
        },
        new()
        {
            Id = 4,
            ModelName = "MC-21-300",
            AirplaneFamily = AirplaneFamilies[3],
            RangeOfFlight = 6000,
            PassengerCapacity = 211,
            CargoCapacity = 22
        },
        new()
        {
            Id = 5,
            ModelName = "E190",
            AirplaneFamily = AirplaneFamilies[4],
            RangeOfFlight = 4400,
            PassengerCapacity = 100,
            CargoCapacity = 10
        },
        new()
        {
            Id = 6,
            ModelName = "CRJ900",
            AirplaneFamily = AirplaneFamilies[5],
            RangeOfFlight = 2800,
            PassengerCapacity = 90,
            CargoCapacity = 8
        },
        new()
        {
            Id = 7,
            ModelName = "Tu-204-300",
            AirplaneFamily = AirplaneFamilies[6],
            RangeOfFlight = 9000,
            PassengerCapacity = 230,
            CargoCapacity = 25
        },
        new()
        {
            Id = 8,
            ModelName = "Il-96-300",
            AirplaneFamily = AirplaneFamilies[7],
            RangeOfFlight = 11000,
            PassengerCapacity = 262,
            CargoCapacity = 40
        },
        new()
        {
            Id = 9,
            ModelName = "A350-900",
            AirplaneFamily = AirplaneFamilies[8],
            RangeOfFlight = 15000,
            PassengerCapacity = 350,
            CargoCapacity = 45
        },
        new()
        {
            Id = 10,
            ModelName = "B777-300ER",
            AirplaneFamily = AirplaneFamilies[9],
            RangeOfFlight = 13650,
            PassengerCapacity = 396,
            CargoCapacity = 50
        }
    ];

    public List<Flight> Flights =>
    [
        new()
        {
            Id = 1,
            FlightNumber = "SU100",
            DepartureAirportCode = "SVO",
            DestinationAirportCode = "LED",
            DepartureDate = new(2025, 10, 1),
            ArrivalDate = new(2025, 10, 1),
            DepartureTime = new(8, 30),
            Duration = TimeSpan.FromHours(1.2),
            AirplaneModel = AirplaneModels[0]
        },
        new()
        {
            Id = 2,
            FlightNumber = "SU101",
            DepartureAirportCode = "LED",
            DestinationAirportCode = "SVO",
            DepartureDate = new(2025, 10, 2),
            ArrivalDate = new(2025, 10, 2),
            DepartureTime = new(12, 0),
            Duration = TimeSpan.FromHours(1.2),
            AirplaneModel = AirplaneModels[1]
        },
        new()
        {
            Id = 3,
            FlightNumber = "AF200",
            DepartureAirportCode = "CDG",
            DestinationAirportCode = "JFK",
            DepartureDate = new(2025, 11, 1),
            ArrivalDate = new(2025, 11, 1),
            DepartureTime = new(10, 15),
            Duration = TimeSpan.FromHours(8),
            AirplaneModel = AirplaneModels[9]
        },
        new()
        {
            Id = 4,
            FlightNumber = "LH300",
            DepartureAirportCode = "FRA",
            DestinationAirportCode = "DXB",
            DepartureDate = new(2025, 12, 1),
            ArrivalDate = new(2025, 12, 1),
            DepartureTime = new(14, 45),
            Duration = TimeSpan.FromHours(6.5),
            AirplaneModel = AirplaneModels[8]
        },
        new()
        {
            Id = 5,
            FlightNumber = "SU400",
            DepartureAirportCode = "SVO",
            DestinationAirportCode = "PEK",
            DepartureDate = new(2025, 12, 5),
            ArrivalDate = new(2025, 12, 5),
            DepartureTime = new(21, 0),
            Duration = TimeSpan.FromHours(7.5),
            AirplaneModel = AirplaneModels[7]
        },
        new()
        {
            Id = 6,
            FlightNumber = "U600",
            DepartureAirportCode = "LTN",
            DestinationAirportCode = "AMS",
            DepartureDate = new(2025, 9, 20),
            ArrivalDate = new(2025, 9, 20),
            DepartureTime = new(7, 10),
            Duration = TimeSpan.FromHours(1),
            AirplaneModel = AirplaneModels[5]
        },
        new()
        {
            Id = 7,
            FlightNumber = "BA700",
            DepartureAirportCode = "LHR",
            DestinationAirportCode = "JFK",
            DepartureDate = new(2025, 9, 25),
            ArrivalDate = new(2025, 9, 25),
            DepartureTime = new(16, 0),
            Duration = TimeSpan.FromHours(8),
            AirplaneModel = AirplaneModels[9]
        },
        new()
        {
            Id = 8,
            FlightNumber = "KL800",
            DepartureAirportCode = "AMS",
            DestinationAirportCode = "NRT",
            DepartureDate = new(2025, 11, 15),
            ArrivalDate = new(2025, 11, 16),
            DepartureTime = new(18, 30),
            Duration = TimeSpan.FromHours(11),
            AirplaneModel = AirplaneModels[8]
        },
        new()
        {
            Id = 9,
            FlightNumber = "SU900",
            DepartureAirportCode = "SVO",
            DestinationAirportCode = "JFK",
            DepartureDate = new(2025, 10, 10),
            ArrivalDate = new(2025, 10, 10),
            DepartureTime = new(13, 20),
            Duration = TimeSpan.FromHours(9),
            AirplaneModel = AirplaneModels[7]
        },
        new()
        {
            Id = 10,
            FlightNumber = "JL1000",
            DepartureAirportCode = "NRT",
            DestinationAirportCode = "HND",
            DepartureDate = new(2025, 12, 31),
            ArrivalDate = new(2025, 12, 31),
            DepartureTime = new(9, 0),
            Duration = TimeSpan.FromHours(1),
            AirplaneModel = AirplaneModels[4]
        }
    ];

    public List<Passenger> Passengers =>
    [
        new()
        {
            Id = 1,
            NumberOfPasspotr = "1234567890",
            FullName = "Jessica Parker",
            BirthDate = new(2004, 6, 28)
        },
        new()
        {
            Id = 2,
            NumberOfPasspotr = "2345678901",
            FullName = "Anna Ivanova",
            BirthDate = new(1985, 3, 15)
        },
        new()
        {
            Id = 3,
            NumberOfPasspotr = "3456789012",
            FullName = "John Smith",
            BirthDate = new(1992, 11, 10)
        },
        new()
        {
            Id = 4,
            NumberOfPasspotr = "4567890123",
            FullName = "Maria Gonzalez",
            BirthDate = new(1988, 7, 7)
        },
        new()
        {
            Id = 5,
            NumberOfPasspotr = "5678901234",
            FullName = "Chen Wei",
            BirthDate = new(1995, 2, 28)
        },
        new()
        {
            Id = 6,
            NumberOfPasspotr = "6789012345",
            FullName = "Fatima Al-Farsi",
            BirthDate = new(1993, 9, 14)
        },
        new()
        {
            Id = 7,
            NumberOfPasspotr = "7890123456",
            FullName = "James Brown",
            BirthDate = new(1980, 12, 1)
        },
        new()
        {
            Id = 8,
            NumberOfPasspotr = "8901234567",
            FullName = "Sophia Lee",
            BirthDate = new(1999, 8, 19)
        },
        new()
        {
            Id = 9,
            NumberOfPasspotr = "9012345678",
            FullName = "Ahmed Khan",
            BirthDate = new(1987, 4, 9)
        },
        new()
        {
            Id = 10,
            NumberOfPasspotr = "0123456789",
            FullName = "Emily Davis",
            BirthDate = new(1991, 6, 30)
        }
    ];

    public List<Ticket> Tickets =>
    [
        new()
        {
            Id = 1,
            FlightInfo = Flights[0],
            PassengerInfo = Passengers[0],
            SeatNumber = "12A",
            HandLuggageAvailability = true,
            TotalBaggageWeight = 15
        },
        new()
        {
            Id = 2,
            FlightInfo = Flights[1],
            PassengerInfo = Passengers[1],
            SeatNumber = "14C",
            HandLuggageAvailability = false,
            TotalBaggageWeight = 20
        },
        new()
        {
            Id = 3,
            FlightInfo = Flights[2],
            PassengerInfo = Passengers[2],
            SeatNumber = "22B",
            HandLuggageAvailability = true,
            TotalBaggageWeight = 10
        },
        new()
        {
            Id = 4,
            FlightInfo = Flights[3],
            PassengerInfo = Passengers[3],
            SeatNumber = "1A",
            HandLuggageAvailability = true,
            TotalBaggageWeight = 8
        },
        new()
        {
            Id = 5,
            FlightInfo = Flights[4],
            PassengerInfo = Passengers[4],
            SeatNumber = "5D",
            HandLuggageAvailability = true,
            TotalBaggageWeight = 25
        },
        new()
        {
            Id = 6,
            FlightInfo = Flights[5],
            PassengerInfo = Passengers[5],
            SeatNumber = "18F",
            HandLuggageAvailability = false,
            TotalBaggageWeight = 30
        },
        new()
        {
            Id = 7,
            FlightInfo = Flights[6],
            PassengerInfo = Passengers[6],
            SeatNumber = "8C",
            HandLuggageAvailability = true,
            TotalBaggageWeight = 12
        },
        new()
        {
            Id = 8,
            FlightInfo = Flights[7],
            PassengerInfo = Passengers[7],
            SeatNumber = "9B",
            HandLuggageAvailability = true,
            TotalBaggageWeight = 18
        },
        new()
        {
            Id = 9,
            FlightInfo = Flights[8],
            PassengerInfo = Passengers[8],
            SeatNumber = "2E",
            HandLuggageAvailability = true,
            TotalBaggageWeight = 28
        },
        new()
        {
            Id = 10,
            FlightInfo = Flights[9],
            PassengerInfo = Passengers[9],
            SeatNumber = "3A",
            HandLuggageAvailability = false,
            TotalBaggageWeight = 22
        }
    ];
}