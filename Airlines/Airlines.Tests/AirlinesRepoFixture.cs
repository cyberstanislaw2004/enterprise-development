using Airlines.Application.Services;
using Airlines.Infrastructure.InMemory.Repositories;
using Airlines.Domain.Dataseeder;

namespace Airlines.Tests;

/// <summary>
/// Fixture for unit tests nitializes services with inMemory repositories with test data
/// </summary>
public class AirlinesRepoFixture
{
    public AirplaneFamilyService AirplaneFamilyService { get; }
    public AirplaneModelService AirplaneModelService { get; }
    public FlightService FlightService { get; }
    public PassengerService PassengerService { get; }
    public TicketService TicketService { get; }

    /// <summary>
    /// Configure all services
    /// </summary>
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