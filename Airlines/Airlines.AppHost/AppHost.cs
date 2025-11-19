var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddSqlServer("MSSQLConnection")
    .AddDatabase("AirlinesDb");

builder.AddProject<Projects.Airlines_Api>("api")
    .WithReference(db, "MSSQLConnection")
    .WaitFor(db);

builder.Build().Run();
