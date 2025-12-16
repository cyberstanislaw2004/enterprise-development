using Airlines.Generator.Nats.Host.Generator;
using Airlines.Generator.Nats.Host.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;

namespace Airlines.Generator.Nats.Host.Services;

/// <summary>
/// Background service for generating and publishing ticket data to NATS.
/// </summary>
public class GeneratorService(IProducerService producer, ILogger<GeneratorService> logger, GeneratorOptions options) : BackgroundService
{
    /// <summary>
    /// Executes the background ticket generation task.
    /// </summary>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Generator started");

        for (var i = 0; i < options.Batches && !stoppingToken.IsCancellationRequested; i++)
        {
            var tickets = TicketGenerator.GenerateTickets(options.BatchSize);

            await producer.SendAsync(tickets);

            logger.LogInformation(
                "Batch {batch}/{total} sent ({count} tickets)",
                i + 1, options.Batches, tickets.Count);

            await Task.Delay(options.Interval, stoppingToken);
        }

        logger.LogInformation("Generator finished");
    }
}