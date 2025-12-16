using Airlines.Dto;

namespace Airlines.Infrastructure.Nats;

/// <summary>
/// DTO for ticket batch structure used in NATS communication.
/// Matches the structure expected by both producer and consumer.
/// </summary>
public class TicketBatchDto
{
    public Guid BatchId { get; set; }
    public List<TicketCreateDto> Data { get; set; } = new();
}