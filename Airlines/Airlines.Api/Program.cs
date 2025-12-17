using Airlines.Application.Services;
using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Infrastructure.Db;
using Airlines.Infrastructure.Db.Repositories;
using Airlines.ServiceDefaults;
using Microsoft.EntityFrameworkCore;
using NATS.Client;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddScoped<IRepository<AirplaneFamily>, DbAirplaneFamilyRepository>();
builder.Services.AddScoped<IRepository<AirplaneModel>, DbAirplaneModelRepository>();
builder.Services.AddScoped<IRepository<Flight>, DbFlightRepository>();
builder.Services.AddScoped<IRepository<Passenger>, DbPassengerRepository>();
builder.Services.AddScoped<IRepository<Ticket>, DbTicketRepository>();

builder.Services.AddApplicationServices();

builder.Services.AddSingleton<IConnection>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();

    var natsConnectionString = config.GetConnectionString("nats");

    var opts = ConnectionFactory.GetDefaultOptions();
    opts.Url = natsConnectionString;

    return new ConnectionFactory().CreateConnection(opts);
});

builder.Services.AddHostedService<Consumer>();

var microsoftConnectionString = builder.Configuration.GetConnectionString("MSSQLConnection")!;
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(microsoftConnectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var basePath = AppContext.BaseDirectory;

    options.IncludeXmlComments(Path.Combine(basePath, "Airlines.Domain.xml"));
    options.IncludeXmlComments(Path.Combine(basePath, "Airlines.Api.xml"));
    options.IncludeXmlComments(Path.Combine(basePath, "Airlines.Application.xml"));
    options.IncludeXmlComments(Path.Combine(basePath, "Airlines.Dto.xml"));
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();