using Airlines.Dto;
using Airlines.Generator.Nats.Host.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NATS.Client.Core;
using NATS.Client.JetStream.Models;
using NATS.Net;
using System.Text.Json;

namespace Airlines.Generator.Nats.Host;

/// <summary>
/// NATS producer service for publishing ticket batches to a JetStream.
/// </summary>
public class NatsProducer(
    IConfiguration configuration,
    INatsConnection connection,
    ILogger<NatsProducer> logger
) : IProducerService
{
    private readonly string _streamName = configuration.GetSection("Nats")["StreamName"] ?? throw new KeyNotFoundException("StreamName section of Nats is missing");
    private readonly string _rawSubject = configuration.GetSection("Nats")["RawSubject"] ?? throw new KeyNotFoundException("RawSubject section of Nats is missing");
    private readonly int _retryCount = configuration.GetValue<int?>("Nats:RetryCount") ?? 5;
    private readonly TimeSpan _retryDelay = configuration.GetValue<TimeSpan?>("Nats:RetryDelay") ?? TimeSpan.FromSeconds(1);
    private readonly TimeSpan _ackTimeout = configuration.GetValue<TimeSpan?>("Nats:AckTimeout") ?? TimeSpan.FromSeconds(5);

    /// <summary>
    /// Sends a batch of tickets to NATS with request-reply pattern.
    /// Creates stream if needed, publishes with reply inbox, awaits ACK with timeout.
    /// </summary>
    public async Task<BatchAckResponse> SendAsync(IList<TicketCreateDto> batch)
    {
        var batchId = Guid.NewGuid();
        var payload = new
        {
            BatchId = batchId,
            Data = batch
        };
        await EnsureConnectedAsync();
        var context = connection.CreateJetStreamContext();
        await context.CreateOrUpdateStreamAsync(new StreamConfig(_streamName, [_rawSubject]));

        var replyInbox = $"_INBOX.{Guid.NewGuid():N}";

        var tcs = new TaskCompletionSource<BatchAckResponse>(TaskCreationOptions.RunContinuationsAsynchronously);

        _ = Task.Run(async () =>
        {
            await foreach (var msg in connection.SubscribeAsync<byte[]>(replyInbox))
            {
                try
                {
                    var ack = JsonSerializer.Deserialize<BatchAckResponse>(msg.Data);
                    if (ack is not null && ack.BatchId == batchId)
                    {
                        tcs.TrySetResult(new BatchAckResponse { BatchId = batchId, InsertedDtos = ack.InsertedDtos });
                        break;
                    }
                }
                catch (Exception ex)
                {
                    logger.LogWarning(ex, "Failed to deserialize ack on inbox {inbox}", replyInbox);
                }
            }
        });

        await connection.PublishAsync(_rawSubject, JsonSerializer.SerializeToUtf8Bytes(payload), replyTo: replyInbox);
        logger.LogInformation("Sent batch {batchId} ({count} items) to {subject}", batchId, batch.Count, _rawSubject);

        using var cts = new CancellationTokenSource(_ackTimeout);
        var completed = await Task.WhenAny(tcs.Task, Task.Delay(Timeout.Infinite, cts.Token));

        if (completed != tcs.Task)
        {
            logger.LogWarning("No ACK received for batch {batchId} within timeout", batchId);
            return new BatchAckResponse { BatchId = batchId };
        }

        return await tcs.Task;
    }

    /// <summary>
    /// Connects to NATS with exponential delay between attempts.
    /// </summary>
    private async Task EnsureConnectedAsync()
    {
        for (var attempt = 1; attempt <= _retryCount; attempt++)
        {
            try
            {
                logger.LogInformation("Connecting to NATS (attempt {attempt}/{max})", attempt, _retryCount);
                await connection.ConnectAsync();
                logger.LogInformation("Connected to NATS");
                return;
            }
            catch (Exception ex) when (attempt < _retryCount)
            {
                var delay = TimeSpan.FromMilliseconds(_retryDelay.TotalMilliseconds * Math.Pow(2, attempt - 1));
                logger.LogWarning(ex, "Failed to connect to NATS, retrying in {delay}", delay);
                await Task.Delay(delay);
            }
        }

        throw new InvalidOperationException($"Failed to connect to NATS after {_retryCount} attempts");
    }
}