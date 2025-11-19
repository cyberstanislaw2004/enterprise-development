using Airlines.Application.Services;
using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Domain.Dataseeder;
using Airlines.Infrastructure.InMemory.Repositories;
using Microsoft.EntityFrameworkCore;
using Airlines.Infrastructure.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Dataseeder>();
builder.Services.AddSingleton<IRepository<AirplaneFamily>, InMemoryAirplaneFamilyRepository>();
builder.Services.AddSingleton<IRepository<AirplaneModel>, InMemoryAirplaneModelRepository>();
builder.Services.AddSingleton<IRepository<Flight>, InMemoryFlightRepository>();
builder.Services.AddSingleton<IRepository<Passenger>, InMemoryPassengerRepository>();
builder.Services.AddSingleton<IRepository<Ticket>, InMemoryTicketRepository>();

builder.Services.AddScoped<AirplaneFamilyService>();
builder.Services.AddScoped<AirplaneModelService>();
builder.Services.AddScoped<FlightService>();
builder.Services.AddScoped<PassengerService>();
builder.Services.AddScoped<TicketService>();

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
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();