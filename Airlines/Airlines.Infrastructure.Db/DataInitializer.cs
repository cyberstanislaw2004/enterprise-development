using Airlines.Domain.Dataseeder;

namespace Airlines.Infrastructure.Db;

public static class DataInitializer
{
    public static async Task SeedEnsureCreated(AppDbContext dbContext)
    {
        var created = dbContext.Database.EnsureCreated();
        if (created)
        {
            
        }
    }
}