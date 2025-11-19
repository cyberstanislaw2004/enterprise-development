using Airlines.Application.Services;
using Airlines.Domain;
using Airlines.Domain.Repositories;
using Airlines.Domain.Dataseeder;
using Airlines.Infrastructure.InMemory.Repositories;
using Microsoft.EntityFrameworkCore;
using Airlines.Infrastructure.Db;
using Airlines.Infrastructure.Db.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<Dataseeder>();
builder.Services.AddScoped<IRepository<AirplaneFamily>, DbAirplaneFamilyRepository>();
builder.Services.AddScoped<IRepository<AirplaneModel>, DbAirplaneModelRepository>();
builder.Services.AddScoped<IRepository<Flight>, DbFlightRepository>();
builder.Services.AddScoped<IRepository<Passenger>, DbPassengerRepository>();
builder.Services.AddScoped<IRepository<Ticket>, DbTicketRepository>();

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