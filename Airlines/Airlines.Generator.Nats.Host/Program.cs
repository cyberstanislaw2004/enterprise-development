using Airlines.Generator.Nats.Host;
using Airlines.Generator.Nats.Host.Options;
using Airlines.Generator.Nats.Host.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NATS.Client.Core;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.Configure<GeneratorOptions>(
    builder.Configuration.GetSection("Generator"));

builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<GeneratorOptions>>().Value);

builder.Services.AddSingleton<INatsConnection>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();

    var url = config.GetConnectionString("nats")
        ?? throw new InvalidOperationException("Nats connection string not configured");

    var opts = new NatsOpts
    {
        Url = url,
        Name = "AirlinesGenerator"
    };

    return new NatsConnection(opts);
});

builder.Services.AddSingleton<NatsProducer>();
builder.Services.AddHostedService<GeneratorService>();

builder.Build().Run();