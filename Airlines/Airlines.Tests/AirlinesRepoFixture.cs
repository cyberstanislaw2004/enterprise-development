using Airlines.Application.Services;
using Airlines.Infrastructure.InMemory.Repositories;
using Airlines.Domain.Dataseeder;

namespace Airlines.Tests;

/// <summary>
/// Fixture for unit tests nitializes services with inMemory repositories with test data
/// </summary>
public class AirlinesRepoFixture
{
    /// <summary>
    /// Service for managing airplane families
    /// </summary>
    public AirplaneFamilyService AirplaneFamilyService { get; }

    /// <summary>
    /// Service for managing airplane models
    /// </summary>
    public AirplaneModelService AirplaneModelService { get; }

    /// <summary>
    /// Service for managing flights
    /// </summary>
    public FlightService FlightService { get; }

    /// <summary>
    /// Service for managing passengers
    /// </summary>
    public PassengerService PassengerService { get; }

    /// <summary>
    /// Service for managing tickets
    /// </summary>
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