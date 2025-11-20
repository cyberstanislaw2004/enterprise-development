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
        services.AddScoped<AirplaneFamilyService>();
        services.AddScoped<AirplaneModelService>();
        services.AddScoped<FlightService>();
        services.AddScoped<PassengerService>();
        services.AddScoped<TicketService>();
        services.AddScoped<AnalyticService>();

        return services;
    }
}
