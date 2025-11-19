using Airlines.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Airlines.Infrastructure.Db;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AirplaneFamily> AirplaneFamilies { get; set; }
    public DbSet<AirplaneModel> AirplaneModels { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AirplaneFamily>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Name).IsRequired();
            entity.Property(x => x.Manufacturer).IsRequired();
        });

        modelBuilder.Entity<AirplaneModel>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.ModelName).IsRequired();
            entity.Property(x => x.RangeOfFlight).IsRequired();
            entity.Property(x => x.PassengerCapacity).IsRequired();
            entity.Property(x => x.CargoCapacity).IsRequired();

            entity
                .HasOne(x => x.AirplaneFamily)
                .WithMany()
                .HasForeignKey("FamilyId")
                .IsRequired();
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.FlightNumber).IsRequired();
            entity.Property(x => x.DepartureAirportCode).IsRequired();
            entity.Property(x => x.DestinationAirportCode).IsRequired();
            entity.Property(x => x.DepartureDate);
            entity.Property(x => x.ArrivalDate);
            entity.Property(x => x.DepartureTime);
            entity.Property(x => x.Duration);

            entity
                .HasOne(x => x.AirplaneModel)
                .WithMany()
                .HasForeignKey("AirplaneModelId")
                .IsRequired();
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.NumberOfPassport).IsRequired();
            entity.Property(x => x.FullName).IsRequired();
            entity.Property(x => x.BirthDate);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.SeatNumber).IsRequired();
            entity.Property(x => x.HandLuggageAvailability).IsRequired();
            entity.Property(x => x.TotalBaggageWeight).IsRequired();

            entity
                .HasOne(x => x.FlightInfo)
                .WithMany()
                .HasForeignKey("FlightId")
                .IsRequired();

            entity
                .HasOne(x => x.PassengerInfo)
                .WithMany()
                .HasForeignKey("PassengerId")
                .IsRequired();
        });
    }
}