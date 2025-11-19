using Airlines.Domain;

namespace Airlines.Domain.Dataseeder;

/// <summary>
/// Dataseed containing instances of classes
/// </summary>
public class Dataseeder
{
    /// <summary>
    /// Instances of the "AirplaneFamily" class
    /// </summary>
    public List<AirplaneFamily> AirplaneFamilies =>
    [
        new AirplaneFamily
        {
            Id = 1,
            Name = "A320",
            Manufacturer = "Airbus"
        },
        new AirplaneFamily
        {
            Id = 2,
            Name = "B737",
            Manufacturer = "Boeing"
        },
        new AirplaneFamily
        {
            Id = 3,
            Name = "SSJ",
            Manufacturer = "Sukhoi"
        },
        new AirplaneFamily
        {
            Id = 4,
            Name = "MC-21",
            Manufacturer = "Irkut"
        },
        new AirplaneFamily
        {
            Id = 5,
            Name = "E190",
            Manufacturer = "Embraer"
        },
        new AirplaneFamily
        {
            Id = 6,
            Name = "CRJ",
            Manufacturer = "Bombardier"
        },
        new AirplaneFamily
        {
            Id = 7,
            Name = "Tu-204",
            Manufacturer = "Tupolev"
        },
        new AirplaneFamily
        {
            Id = 8,
            Name = "Il-96",
            Manufacturer = "Ilyushin"
        },
        new AirplaneFamily
        {
            Id = 9,
            Name = "A350",
            Manufacturer = "Airbus"
        },
        new AirplaneFamily
        {
            Id = 10,
            Name = "B777",
            Manufacturer = "Boeing"
        }
    ];

    /// <summary>
    /// Instances of the "AirplaneModel" class
    /// </summary>
    public List<AirplaneModel> AirplaneModels =>
    [
        new AirplaneModel
        {
            Id = 1,
            ModelName = "A320-200",
            FamilyId = 1,
            //AirplaneFamily = AirplaneFamilies[0],
            AirplaneFamily = null,
            RangeOfFlight = 6100,
            PassengerCapacity = 180,
            CargoCapacity = 20
        },
        new AirplaneModel
        {
            Id = 2,
            ModelName = "737-800",
            FamilyId = 2,
            //AirplaneFamily = AirplaneFamilies[1],
            AirplaneFamily = null,
            RangeOfFlight = 5436,
            PassengerCapacity = 189,
            CargoCapacity = 18
        },
        new AirplaneModel
        {
            Id = 3,
            ModelName = "SSJ100",
            FamilyId = 3,
            //AirplaneFamily = AirplaneFamilies[2],
            AirplaneFamily = null,
            RangeOfFlight = 4500,
            PassengerCapacity = 108,
            CargoCapacity = 12
        },
        new AirplaneModel
        {
            Id = 4,
            ModelName = "MC-21-300",
            FamilyId = 4,
            //AirplaneFamily = AirplaneFamilies[3],
            AirplaneFamily = null,
            RangeOfFlight = 6000,
            PassengerCapacity = 211,
            CargoCapacity = 22
        },
        new AirplaneModel
        {
            Id = 5,
            ModelName = "E190",
            FamilyId = 5,
            //AirplaneFamily = AirplaneFamilies[4],
            AirplaneFamily = null,
            RangeOfFlight = 4400,
            PassengerCapacity = 100,
            CargoCapacity = 10
        },
        new AirplaneModel
        {
            Id = 6,
            ModelName = "CRJ900",
            FamilyId = 6,
            //AirplaneFamily = AirplaneFamilies[5],
            AirplaneFamily = null,
            RangeOfFlight = 2800,
            PassengerCapacity = 90,
            CargoCapacity = 8
        },
        new AirplaneModel
        {
            Id = 7,
            ModelName = "Tu-204-300",
            FamilyId = 7,
            //AirplaneFamily = AirplaneFamilies[6],
            AirplaneFamily = null,
            RangeOfFlight = 9000,
            PassengerCapacity = 230,
            CargoCapacity = 25
        },
        new AirplaneModel
        {
            Id = 8,
            ModelName = "Il-96-300",
            FamilyId = 8,
            //AirplaneFamily = AirplaneFamilies[7],
            AirplaneFamily = null,
            RangeOfFlight = 11000,
            PassengerCapacity = 262,
            CargoCapacity = 40
        },
        new AirplaneModel
        {
            Id = 9,
            ModelName = "A350-900",
            FamilyId = 9,
            //AirplaneFamily = AirplaneFamilies[8],
            AirplaneFamily = null,
            RangeOfFlight = 15000,
            PassengerCapacity = 350,
            CargoCapacity = 45
        },
        new AirplaneModel
        {
            Id = 10,
            ModelName = "B777-300ER",
            FamilyId = 10,
            //AirplaneFamily = AirplaneFamilies[9],
            AirplaneFamily = null,
            RangeOfFlight = 13650,
            PassengerCapacity = 396,
            CargoCapacity = 50
        }
    ];

    /// <summary>
    /// Instances of the "Flight" class
    /// </summary>
    public List<Flight> Flights =>
    [
        new Flight
        {
            Id = 1,
            FlightNumber = "SU100",
            DepartureAirportCode = "SVO",
            DestinationAirportCode = "LED",
            DepartureDate = new(2025, 10, 1),
            ArrivalDate = new(2025, 10, 1),
            DepartureTime = new(8, 30),
            Duration = TimeSpan.FromHours(1.2),
            AirplaneModelId = 1,
            //AirplaneModel = AirplaneModels[0]
            AirplaneModel = null
        },
        new Flight
        {
            Id = 2,
            FlightNumber = "SU101",
            DepartureAirportCode = "SVO",
            DestinationAirportCode = "LED",
            DepartureDate = new(2025, 10, 2),
            ArrivalDate = new(2025, 10, 2),
            DepartureTime = new(12, 0),
            Duration = TimeSpan.FromHours(1.2),
            AirplaneModelId = 2,
            //AirplaneModel = AirplaneModels[1]
            AirplaneModel = null
        },
        new Flight
        {
            Id = 3,
            FlightNumber = "AF200",
            DepartureAirportCode = "CDG",
            DestinationAirportCode = "JFK",
            DepartureDate = new(2025, 11, 1),
            ArrivalDate = new(2025, 11, 1),
            DepartureTime = new(10, 15),
            Duration = TimeSpan.FromHours(8),
            AirplaneModelId = 10,
            //AirplaneModel = AirplaneModels[9]
            AirplaneModel = null
        },
        new Flight
        {
            Id = 4,
            FlightNumber = "LH300",
            DepartureAirportCode = "FRA",
            DestinationAirportCode = "DXB",
            DepartureDate = new(2025, 12, 1),
            ArrivalDate = new(2025, 12, 1),
            DepartureTime = new(14, 45),
            Duration = TimeSpan.FromHours(6.5),
            AirplaneModelId = 9,
            //AirplaneModel = AirplaneModels[8]
            AirplaneModel = null
        },
        new Flight
        {
            Id = 5,
            FlightNumber = "SU400",
            DepartureAirportCode = "SVO",
            DestinationAirportCode = "PEK",
            DepartureDate = new(2025, 12, 5),
            ArrivalDate = new(2025, 12, 5),
            DepartureTime = new(21, 0),
            Duration = TimeSpan.FromHours(7.5),
            AirplaneModelId = 8,
            //AirplaneModel = AirplaneModels[7]
            AirplaneModel = null
        },
        new Flight
        {
            Id = 6,
            FlightNumber = "U600",
            DepartureAirportCode = "LTN",
            DestinationAirportCode = "AMS",
            DepartureDate = new(2025, 9, 20),
            ArrivalDate = new(2025, 9, 20),
            DepartureTime = new(7, 10),
            Duration = TimeSpan.FromHours(1),
            AirplaneModelId = 6,
            //AirplaneModel = AirplaneModels[5]
            AirplaneModel = null
        },
        new Flight
        {
            Id = 7,
            FlightNumber = "BA700",
            DepartureAirportCode = "LHR",
            DestinationAirportCode = "JFK",
            DepartureDate = new(2025, 9, 25),
            ArrivalDate = new(2025, 9, 25),
            DepartureTime = new(16, 0),
            Duration = TimeSpan.FromHours(8),
            AirplaneModelId = 10,
            //AirplaneModel = AirplaneModels[9]
            AirplaneModel = null
        },
        new Flight
        {
            Id = 8,
            FlightNumber = "KL800",
            DepartureAirportCode = "AMS",
            DestinationAirportCode = "NRT",
            DepartureDate = new(2025, 11, 15),
            ArrivalDate = new(2025, 11, 16),
            DepartureTime = new(18, 30),
            Duration = TimeSpan.FromHours(11),
            AirplaneModelId = 9,
            //AirplaneModel = AirplaneModels[8]
            AirplaneModel = null
        },
        new Flight
        {
            Id = 9,
            FlightNumber = "SU900",
            DepartureAirportCode = "SVO",
            DestinationAirportCode = "JFK",
            DepartureDate = new(2025, 10, 10),
            ArrivalDate = new(2025, 10, 10),
            DepartureTime = new(13, 20),
            Duration = TimeSpan.FromHours(9),
            AirplaneModelId = 8,
            //AirplaneModel = AirplaneModels[7]
            AirplaneModel = null
        },
        new Flight
        {
            Id = 10,
            FlightNumber = "JL1000",
            DepartureAirportCode = "NRT",
            DestinationAirportCode = "HND",
            DepartureDate = new(2025, 12, 31),
            ArrivalDate = new(2025, 12, 31),
            DepartureTime = new(9, 0),
            Duration = TimeSpan.FromHours(1.1),
            AirplaneModelId = 5,
            //AirplaneModel = AirplaneModels[4]
            AirplaneModel = null
        }
    ];

    /// <summary>
    /// Instances of the "Passenger" class
    /// </summary>
    public List<Passenger> Passengers =>
    [
        new Passenger
        {
            Id = 1,
            NumberOfPassport = "1234567890",
            FullName = "Jessica Parker",
            BirthDate = new(2004, 6, 28)
        },
        new Passenger
        {
            Id = 2,
            NumberOfPassport = "2345678901",
            FullName = "Anna Ivanova",
            BirthDate = new(1985, 3, 15)
        },
        new Passenger
        {
            Id = 3,
            NumberOfPassport = "3456789012",
            FullName = "John Smith",
            BirthDate = new(1992, 11, 10)
        },
        new Passenger
        {
            Id = 4,
            NumberOfPassport = "4567890123",
            FullName = "Maria Gonzalez",
            BirthDate = new(1988, 7, 7)
        },
        new Passenger
        {
            Id = 5,
            NumberOfPassport = "5678901234",
            FullName = "Chen Wei",
            BirthDate = new(1995, 2, 28)
        },
        new Passenger
        {
            Id = 6,
            NumberOfPassport = "6789012345",
            FullName = "Fatima Al-Farsi",
            BirthDate = new(1993, 9, 14)
        },
        new Passenger
        {
            Id = 7,
            NumberOfPassport = "7890123456",
            FullName = "James Brown",
            BirthDate = new(1980, 12, 1)
        },
        new Passenger
        {
            Id = 8,
            NumberOfPassport = "8901234567",
            FullName = "Sophia Lee",
            BirthDate = new(1999, 8, 19)
        },
        new Passenger
        {
            Id = 9,
            NumberOfPassport = "9012345678",
            FullName = "Ahmed Khan",
            BirthDate = new(1987, 4, 9)
        },
        new Passenger
        {
            Id = 10,
            NumberOfPassport = "0123456789",
            FullName = "Emily Davis",
            BirthDate = new(1991, 6, 30)
        }
    ];

    /// <summary>
    /// Instances of the "Ticket" class
    /// </summary>
    public List<Ticket> Tickets =>
    [
        new Ticket
        {
            Id = 1,
            FlightId = 1,
            //FlightInfo = Flights[0],
            FlightInfo = null,
            PassengerId = 1,
            //PassengerInfo = Passengers[0],
            PassengerInfo = null,
            SeatNumber = "12A",
            HandLuggageAvailability = true,
            TotalBaggageWeight = 0
        },
        new Ticket
        {
            Id = 2,
            FlightId = 1,
            //FlightInfo = Flights[0],
            FlightInfo = null,
            PassengerId = 2,
            //PassengerInfo = Passengers[1],
            PassengerInfo = null,
            SeatNumber = "14C",
            HandLuggageAvailability = false,
            TotalBaggageWeight = 20
        },
        new Ticket
        {
            Id = 3,
            FlightId = 1,
            //FlightInfo = Flights[0],
            FlightInfo = null,
            PassengerId = 3,
            //PassengerInfo = Passengers[2],
            PassengerInfo = null,
            SeatNumber = "22B",
            HandLuggageAvailability = true,
            TotalBaggageWeight = 0
        },
        new Ticket
        {
            Id = 4,
            FlightId = 3,
            //FlightInfo = Flights[2],
            FlightInfo = null,
            PassengerId = 4,
            //PassengerInfo = Passengers[3],
            PassengerInfo = null,
            SeatNumber = "1A",
            HandLuggageAvailability = true,
            TotalBaggageWeight = 8
        },
        new Ticket
        {
            Id = 5,
            FlightId = 5,
            //FlightInfo = Flights[4],
            FlightInfo = null,
            PassengerId = 5,
            //PassengerInfo = Passengers[4],
            PassengerInfo = null,
            SeatNumber = "5D",
            HandLuggageAvailability = true,
            TotalBaggageWeight = 25
        },
        new Ticket
        {
            Id = 6,
            FlightId = 6,
            //FlightInfo = Flights[5],
            FlightInfo = null,
            PassengerId = 6,
            //PassengerInfo = Passengers[5],
            PassengerInfo = null,
            SeatNumber = "18F",
            HandLuggageAvailability = false,
            TotalBaggageWeight = 30
        },
        new Ticket
        {
            Id = 7,
            FlightId = 6,
            //FlightInfo = Flights[5],
            FlightInfo = null,
            PassengerId = 7,
            //PassengerInfo = Passengers[6],
            PassengerInfo = null,
            SeatNumber = "8C",
            HandLuggageAvailability = true,
            TotalBaggageWeight = 12
        },
        new Ticket
        {
            Id = 8,
            FlightId = 8,
            //FlightInfo = Flights[7],
            FlightInfo = null,
            PassengerId = 8,
            //PassengerInfo = Passengers[7],
            PassengerInfo = null,
            SeatNumber = "9B",
            HandLuggageAvailability = true,
            TotalBaggageWeight = 18
        },
        new Ticket
        {
            Id = 9,
            FlightId = 9,
            //FlightInfo = Flights[8],
            FlightInfo = null,
            PassengerId = 9,
            //PassengerInfo = Passengers[8],
            PassengerInfo = null,
            SeatNumber = "2E",
            HandLuggageAvailability = true,
            TotalBaggageWeight = 28
        },
        new Ticket
        {
            Id = 10,
            FlightId = 10,
            //FlightInfo = Flights[9],
            FlightInfo = null,
            PassengerId = 10,
            //PassengerInfo = Passengers[9],
            PassengerInfo = null,
            SeatNumber = "3A",
            HandLuggageAvailability = false,
            TotalBaggageWeight = 22
        }
    ];
}