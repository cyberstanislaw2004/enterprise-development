namespace Airlines.Generator.Nats.Host.Options;

/// <summary>
/// Configuration options for the NATS ticket generator.
/// Controls the behavior of ticket generation and publishing to NATS.
/// </summary>
public sealed class GeneratorOptions
{
    /// <summary>
    /// Number of tickets to generate in each batch.
    /// Default: 10 tickets per batch.
    /// </summary>
    public int BatchSize { get; init; } = 10;

    /// <summary>
    /// Number of batches to generate.
    /// Default: 5 batches.
    /// </summary>
    public int Batches { get; init; } = 5;

    /// <summary>
    /// Time interval between generating batches.
    /// Default: 2 seconds between batches.
    /// </summary>
    public TimeSpan Interval { get; init; } = TimeSpan.FromSeconds(2);
}