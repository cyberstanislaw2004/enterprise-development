var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddSqlServer("MSSQLConnection")
    .AddDatabase("AirlinesDb");

var apiHost = builder.AddProject<Projects.Airlines_Api>("api")
    .WithReference(db, "MSSQLConnection")
    .WaitFor(db);

var batchSize = builder.AddParameter("GeneratorBatchSize");
var payloadLimit = builder.AddParameter("GeneratorPayloadLimit");
var waitTime = builder.AddParameter("GeneratorWaitTime");

var nats = builder.AddNats("nats")
    .WithJetStream()
    .WithArgs("-m", "8222")
    .WithHttpEndpoint(port: 8222, targetPort: 8222);

builder.AddContainer("airlines-nui", "ghcr.io/nats-nui/nui")
    .WithReference(nats)
    .WaitFor(nats)
    .WithHttpEndpoint(port: 31311, targetPort: 31311);

var natsStream = builder.AddParameter("NatsStream");
var rawSubject = builder.AddParameter("RawSubject");
var validatedSubject = builder.AddParameter("ValidatedSubject");
builder.AddProject<Projects.Airlines_Generator_Nats_Host>("airlines-generator-nats-host")
    .WithReference(nats)
    .WaitFor(nats);

apiHost.WithReference(nats)
       .WaitFor(nats);

builder.Build().Run();