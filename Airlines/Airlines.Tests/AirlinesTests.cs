using Airlines.Domain;
using Airlines.Infrastructure.InMemory.Dataseeder;

namespace Airlines.Tests;

public class AirlinesTests(InMemoryRepositoryDataseeder fixture): IClassFixture<InMemoryRepositoryDataseeder>
{
    /// <summary>
    /// Display the top 5 flights by the number of passengers carried.
    /// </summary>
    [Fact]
    public void GetTopFiveFlights_WhenFlightsExist_ReturnsFlightsInDescendingPassengerCount()
    {
        var topFive = (
            from flight in fixture.Flights
            let passengerCount =
                (from ticket in fixture.Tickets
                where ticket.FlightInfo == flight
                select ticket).Count()
            orderby passengerCount descending
            select new
            {
                Flight = flight.FlightNumber,
                PassengerCount = passengerCount
            })
            .Take(5)
            .ToList();

        Assert.Equal(5, topFive.Count());
        for (var i = 0; i < topFive.Count() - 1; i++) Assert.True(topFive[i].PassengerCount >= topFive[i + 1].PassengerCount);
    }

    /// <summary>
    /// Display a list of flights with the minimum travel time.
    /// </summary>
    [Fact]
    public void GetFlightsWithMinDuration_WhenFlightsExist_ReturnsAllWithMinDuration()
    {
        var minDuration = (
            from flight in fixture.Flights
            where flight.Duration == fixture.Flights.Min(f => f.Duration)
            select new
            {
                Flight = flight.FlightNumber,
                Duration = flight.Duration
            })
            .ToList();

        Assert.NotEmpty(minDuration);

        var expectedMinDuration = fixture.Flights.Min(f => f.Duration);

        for (var i = 0; i < minDuration.Count(); i++) Assert.True(minDuration[i].Duration == expectedMinDuration);
    }

    /// <summary>
    /// Display information about all passengers flying on the selected flight
    /// whose baggage weight is zero, sorted by full name.
    /// </summary>
    [Fact]
    public void GetPassengersWithZeroBaggage_OnSelectedFlight_ReturnsPassengersOrderedByFullName()
    {
        var selectedFlight = fixture.Flights.First(f => f.FlightNumber == "SU100");

        var infoAboutPassenger = (
            from ticket in fixture.Tickets
            where ticket.TotalBaggageWeight == 0
                && ticket.FlightInfo.FlightNumber == selectedFlight.FlightNumber
            orderby ticket.PassengerInfo.FullName
            select ticket.PassengerInfo)
            .ToList();

        Assert.NotEmpty(infoAboutPassenger);
        
        foreach (var passenger in infoAboutPassenger)
        {
            Assert.Equal(selectedFlight.FlightNumber, fixture.Tickets.First(t => t.PassengerInfo.Id == passenger.Id).FlightInfo.FlightNumber);
            Assert.Equal(0, fixture.Tickets.First(t => t.PassengerInfo.Id == passenger.Id).TotalBaggageWeight);
        }

        for (var i = 0; i < infoAboutPassenger.Count() - 1; i++) Assert.True(string.Compare(infoAboutPassenger[i].FullName, infoAboutPassenger[i + 1].FullName) <= 0);
    }

    /// <summary>
    /// Display summary information about all flights of aircraft 
    /// of the selected model during a specified period of time.
    /// </summary>
    [Fact]
    public void GetFlightsByModelWithinPeriod_WhenFlightsExist_ReturnsMatchingFlightNumbers()
    {
        var selectedModel = "Il-96-300";
        var startDate = new DateOnly(2025, 10, 10);
        var endDate = new DateOnly(2025, 12, 5);

        var allFlights = (
            from flight in fixture.Flights
            where flight.AirplaneModel.ModelName == selectedModel
                && flight.DepartureDate >= startDate
                && flight.ArrivalDate <= endDate
            select flight.FlightNumber)
            .ToList();

        var expectedData = new[]
        {
            "SU400",
            "SU900"
        };

        Assert.Equal(expectedData, allFlights);
    }

    /// <summary>
    /// Display information about all flights departing from a specified
    /// departure point to a specified arrival point.
    /// </summary>
    [Fact]
    public void GetFlightsByDepartureAndDestination_WhenFlightsExist_ReturnsMatchingFlightNumbers()
    {
        var startSpot = "SVO";
        var endSpot = "LED";

        var allFlights = (
            from flight in fixture.Flights
            where flight.DepartureAirportCode == startSpot
                && flight.DestinationAirportCode == endSpot
            select flight.FlightNumber).ToList();

        var expectedData = new[]
        {
            "SU100",
            "SU101"
        };

        Assert.Equal(expectedData, allFlights);
    }
}