using Bogus;
using Airlines.Dto;

namespace Airlines.Generator.Nats.Host.Generator;

/// <summary>
/// Class for generating random contracts
/// </summary>
public static class TicketGenerator
{
    /// <summary>
    /// Method for generating user numbers count contracts with a rules
    /// </summary>
    public static List<TicketCreateDto> GenerateTickets(int count) =>
        new Faker<TicketCreateDto>()
            .CustomInstantiator(f => new TicketCreateDto(
                seatNumber: $"{f.Random.Char('A', 'F')}{f.Random.Int(1, 40)}",
                handLuggageAvailability: f.Random.Bool(),
                totalBaggageWeight: f.Random.Double(0, 30),
                flightId: f.Random.Int(1, 10),
                passengerId: f.Random.Int(1, 10)
            ))
            .Generate(count);
}