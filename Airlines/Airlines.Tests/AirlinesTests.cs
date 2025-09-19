using Airlines.Domain;
using Airlines.Domain.Fixture;
using System;

namespace Airlines.Tests;

public class AirlinesTests(AirlinesFixture fixture): IClassFixture<AirlinesFixture>
{
    [Fact]
    public void TopFiveFlights() // Вывести топ 5 авиарейсов по количеству перевезенных пассажиров.
    {

        // const List<Flight> TopFive = {}
        var topFive = (
            from flight in fixture.Flights
            let passengerCount = (
                from ticket in fixture.Tickets
                where ticket.FlightInfo == flight
                select ticket).Count()
            orderby passengerCount descending
            select new
            {
                Flight = flight.FlightNumber,
                PassengerCount = passengerCount
            }).Take(5).ToList();

        // foreach(var c in topFive)
        //{
        // System.Diagnostics.Debug.WriteLine($"Рейс: {c.Flight}; Количество перевезенных пассажиров: {c.PassengetCount}");
        //Console.WriteLine($"Рейс: {c.Flight}; Количество перевезенных пассажиров: {c.PassengerCount}");
        // }

        Assert.Equal(5, topFive.Count()); // убедились, что 5 элементов в списке
        for (var i = 0; i < topFive.Count() - 1; i++)
        {
            Assert.True(topFive[i].PassengerCount >= topFive[i + 1].PassengerCount); // тут мы убеждаемся, что в нашем списке, количество пассажиров в каждой строчке такое же или меньше, чем в предыдущей
        }
    }

    [Fact]
    public void ListOfFlightsWithMinTimeInTravel() // Вывести список рейсов с минимальным временем в пути.
    {
        var minDuration = (
            from flight in fixture.Flights
            where flight.Duration == fixture.Flights.Min(f => f.Duration)
            select new
            {
                Flight = flight.FlightNumber,
                Duration = flight.Duration
            }).ToList();

        Assert.NotEmpty(minDuration);

        var expectedMinDuration = fixture.Flights.Min(f => f.Duration);

        for (var i = 0; i < minDuration.Count(); i++)
        {
            Assert.True(minDuration[i].Duration == expectedMinDuration);
        }
    }

    [Fact]
    public void InfoAboutAllPassengers() // Вывести сведения обо всех пассажирах, летящих выбранным рейсом, вес багажа которых равен нулю, упорядочить по ФИО.
    {
        var selectedFlight = fixture.Flights.First(f => f.FlightNumber == "SU100");

        var infoAboutPassenger = (
            from ticket in fixture.Tickets
            where ticket.TotalBaggageWeight == 0
            && ticket.FlightInfo.FlightNumber == selectedFlight.FlightNumber
            orderby ticket.PassengerInfo.FullName
            select ticket.PassengerInfo).ToList();

        Assert.NotEmpty(infoAboutPassenger); // смотрим что кто то есть
        
        foreach (var passenger in infoAboutPassenger)
        {
            Assert.Equal(selectedFlight.FlightNumber, fixture.Tickets.First(t => t.PassengerInfo.Id == passenger.Id).FlightInfo.FlightNumber); // смотрим что наш летит туда куда надо
            Assert.Equal(0, fixture.Tickets.First(t => t.PassengerInfo.Id == passenger.Id).TotalBaggageWeight); // смотрим что пустой багаж
        }
        for (var i = 0; i < infoAboutPassenger.Count() - 1; i++)
        {
            Assert.True(string.Compare(infoAboutPassenger[i].FullName, infoAboutPassenger[i + 1].FullName) <= 0); // смотрим что правильно отсортировано
        }

    }

    [Fact]
    public void InfoAboutAllFlightsSelectedModel() // Вывести сводную информацию обо всех полетах самолетов выбранной модели в указанный период времени.
    {
        var selectedModel = "Il-96-300";
        var startDate = new DateOnly(2025, 10, 10);
        var endDate = new DateOnly(2025, 12, 5);

        var allFlights = (
            from flight in fixture.Flights
            where flight.AirplaneModel.ModelName == selectedModel
            && flight.DepartureDate >= startDate
            && flight.ArrivalDate <= endDate
            select flight.FlightNumber).ToList();

        var expectedData = new[]
        {
            "SU400",
            "SU900"
        };

        Assert.Equal(expectedData, allFlights);
    }

    [Fact]
    public void InfoAboutAllFlightsSelectedSpot() // Вывести сведения о всех авиарейсах, вылетевших из указанного пункта отправления в указанный пункт прибытия.
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