using Airlines.Dto;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NATS.Client;
using NATS.Client.JetStream;
using System.Text.Json;
using Airlines.Application.Interfaces;

/// <summary>
/// NATS JetStream consumer service for processing ticket batches from messaging queue.
/// </summary>
public class Consumer : BackgroundService
{
    private readonly ILogger<Consumer> _logger;
    private readonly IConnection _natsConnection;
    private readonly IServiceScopeFactory _scopeFactory;

    public Consumer(
        ILogger<Consumer> logger,
        IConnection natsConnection,
        IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _natsConnection = natsConnection;
        _scopeFactory = scopeFactory;
    }

    /// <summary>
    /// Internal class representing ticket batch structure from NATS.
    /// </summary>
    private class TicketBatch
    {
        public Guid BatchId { get; set; }
        public List<TicketCreateDto> Data { get; set; } = new();
    }

    /// <summary>
    /// Main consumer loop - pulls messages from JetStream and processes ticket batches.
    /// </summary>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Starting NATS JetStream consumer...");

        IJetStream js = _natsConnection.CreateJetStreamContext();
        var pullOpts = PullSubscribeOptions.Builder()
            .WithStream("airlines")
            .WithDurable("consumer1")
            .Build();

        var sub = js.PullSubscribe("tickets.raw", pullOpts);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var messages = sub.Fetch(10, 1000);

                foreach (var msg in messages)
                {
                    try
                    {
                        var batch = JsonSerializer.Deserialize<TicketBatch>(msg.Data);

                        if (batch?.Data == null || batch.Data.Count == 0)
                        {
                            _logger.LogWarning("Received empty or invalid batch, skipping");
                            msg.Ack();
                            continue;
                        }

                        using var scope = _scopeFactory.CreateScope();
                        var ticketService = scope.ServiceProvider.GetRequiredService<ITicketService>();

                        foreach (var ticketDto in batch.Data)
                        {
                            try
                            {
                                await ticketService.CreateTicketAsync(ticketDto);
                                _logger.LogInformation(
                                    "Ticket for Flight {FlightId} and Passenger {PassengerId} saved successfully",
                                    ticketDto.FlightId,
                                    ticketDto.PassengerId
                                );
                            }
                            catch (ArgumentException ex)
                            {
                                _logger.LogWarning(
                                    "Skipping ticket with FlightId={FlightId}, PassengerId={PassengerId}: {Message}",
                                    ticketDto.FlightId,
                                    ticketDto.PassengerId,
                                    ex.Message
                                );
                            }
                        }

                        msg.Ack();
                    }
                    catch (JsonException jex)
                    {
                        _logger.LogError(jex, "Failed to deserialize ticket batch");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error processing ticket batch");
                    }
                }
            }
            catch (NATSTimeoutException)
            {
            }
        }
    }
}