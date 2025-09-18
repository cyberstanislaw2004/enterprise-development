using Airlines.Domain;
using Airlines.Domain.Fixture;

namespace Airlines.Tests;

public class AirlinesTests(AirlinesFixture fixture): IClassFixture<AirlinesFixture>
{
    [Fact]
    public void TopFiveFlights() // Вывести топ 5 авиарейсов по количеству перевезенных пассажиров.
    {
        const List<Flight> TopFive = {}
    }
}
