using Airlines.Domain.Dataseeder;

namespace Airlines.Infrastructure.Db;

public static class DataInitializer
{

    public static async Task SeedEnsureCreated(AppDbContext dbContext)
    {
        var dataseeder = new Dataseeder();
        var created = dbContext.Database.EnsureCreated();
        if (created)
        {
            await dbContext.AirplaneFamilies.AddRangeAsync(dataseeder.AirplaneFamilies);
            await dbContext.AirplaneModels.AddRangeAsync(dataseeder.AirplaneModels);
            await dbContext.Flights.AddRangeAsync(dataseeder.Flights);
            await dbContext.Passengers.AddRangeAsync(dataseeder.Passengers);
            await dbContext.Tickets.AddRangeAsync(dataseeder.Tickets);

            await dbContext.SaveChangesAsync();
        }
    }

    public static async Task Seed(AppDbContext dbContext)
    {
        var dataseeder = new Dataseeder();
        if (!dbContext.AirplaneFamilies.Any() && !dbContext.AirplaneModels.Any() && !dbContext.Flights.Any() && !dbContext.Passengers.Any() && !dbContext.Tickets.Any())
        {
            await dbContext.AirplaneFamilies.AddRangeAsync(dataseeder.AirplaneFamilies);
            await dbContext.AirplaneModels.AddRangeAsync(dataseeder.AirplaneModels);
            await dbContext.Flights.AddRangeAsync(dataseeder.Flights);
            await dbContext.Passengers.AddRangeAsync(dataseeder.Passengers);
            await dbContext.Tickets.AddRangeAsync(dataseeder.Tickets);

            await dbContext.SaveChangesAsync();
        }
    }
}