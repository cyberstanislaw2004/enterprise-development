using Airlines.Dto;

namespace Airlines.Generator.Nats.Host.Services;

/// <summary>
/// Interface for a service that publishes ticket data batches to NATS.
/// </summary>
public interface IProducerService
{
    /// <summary>
    /// Sends a batch of ticket creation DTOs to NATS.
    /// </summary>
    public Task<BatchAckResponse> SendAsync(IList<TicketCreateDto> batch);
}