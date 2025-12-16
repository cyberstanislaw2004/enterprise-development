using Airlines.Generator.Nats.Host;
using Airlines.Generator.Nats.Host.Options;
using Airlines.Generator.Nats.Host.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NATS.Client.Core;
using Airlines.Dto;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.Configure<GeneratorOptions>(
    builder.Configuration.GetSection("Generator"));

builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<GeneratorOptions>>().Value);

builder.Services.AddSingleton<INatsConnection>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();

    // Берём значения из окружения, если их нет — ставим дефолт
    var host = config["Nats:Host"] ?? "localhost";
    var port = config["Nats:Port"] ?? "4222";
    var user = config["Nats:Login"] ?? "ruser";
    var pass = config["Nats:Password"] ?? "T0pS3cr3t";

    var url = $"nats://{user}:{pass}@{host}:{port}";

    var opts = new NatsOpts
    {
        Url = url,
        Name = "AirlinesGenerator"
    };

    return new NatsConnection(opts);
});

// builder.Services.AddNatsClient();

builder.Services.AddSingleton<IProducerService, NatsProducer>();
builder.Services.AddHostedService<GeneratorService>();

builder.Build().Run();