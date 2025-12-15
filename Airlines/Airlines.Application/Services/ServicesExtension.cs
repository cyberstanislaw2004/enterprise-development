using Airlines.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Airlines.Application.Services;

/// <summary>
/// Extension methods for registering application services
/// </summary>
public static class ServicesExtension
{
    /// <summary>
    /// Registers all application services
    /// </summary>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAirplaneFamilyService, AirplaneFamilyService>();
        services.AddScoped<IAirplaneModelService, AirplaneModelService>();
        services.AddScoped<IFlightService, FlightService>();
        services.AddScoped<IPassengerService, PassengerService>();
        services.AddScoped<ITicketService, TicketService>();
        services.AddScoped<IAnalyticService, AnalyticService>();

        return services;
    }
}
