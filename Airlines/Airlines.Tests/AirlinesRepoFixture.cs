using Airlines.Application.Services;
using Airlines.Infrastructure.InMemory.Repositories;
using Airlines.Domain.Dataseeder;

namespace Airlines.Tests;

public class AirlinesRepoFixture
{
    public AirplaneFamilyService AirplaneFamilyService { get; }
    public AirplaneModelService AirplaneModelService { get; }
    public FlightService FlightService { get; }
    public PassengerService PassengerService { get; }
    public TicketService TicketService { get; }

    public AirlinesRepoFixture()
    {
        var dataseeder = new Dataseeder();

        var airplaneFamilyRepository = new InMemoryAirplaneFamilyRepository(dataseeder);
        var airplaneModelRepository = new InMemoryAirplaneModelRepository(dataseeder);
        var flightRepository = new InMemoryFlightRepository(dataseeder);
        var passengerRepository = new InMemoryPassengerRepository(dataseeder);
        var ticketRepository = new InMemoryTicketRepository(dataseeder);


        AirplaneFamilyService = new AirplaneFamilyService(airplaneFamilyRepository);
        AirplaneModelService = new AirplaneModelService(airplaneModelRepository);
        FlightService = new FlightService(flightRepository);
        PassengerService = new PassengerService(passengerRepository);
        TicketService = new TicketService(ticketRepository);
    }
}