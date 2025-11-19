using Airlines.Domain;
using Airlines.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Airlines.Infrastructure.Db.Repositories;

public class DbTicketRepository(AppDbContext dbContext) : IRepository<Ticket>
{
    public int Create(Ticket entity)
    {
        dbContext.Tickets.Add(entity);
        dbContext.SaveChanges();
        return entity.Id;
    }

    public List<Ticket> Read()
    {
        return dbContext.Tickets
            .Include(t => t.FlightInfo)
                .ThenInclude(f => f.AirplaneModel)
                    .ThenInclude(m => m.AirplaneFamily)
            .Include(t => t.PassengerInfo)
            .AsNoTracking()
            .ToList();
    }

    public Ticket? Read(int id)
    {
        return dbContext.Tickets
            .Include(t => t.FlightInfo)
                .ThenInclude(f => f.AirplaneModel)
                    .ThenInclude(m => m.AirplaneFamily)
            .Include(t => t.PassengerInfo)
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
    }

    public Ticket? Update(int id, Ticket entity)
    {
        var existingEntity = dbContext.Tickets.Find(id);
        if (existingEntity == null)
        {
            return null;
        }

        existingEntity.SeatNumber = entity.SeatNumber;
        existingEntity.HandLuggageAvailability = entity.HandLuggageAvailability;
        existingEntity.TotalBaggageWeight = entity.TotalBaggageWeight;
        existingEntity.FlightId = entity.FlightId;
        existingEntity.PassengerId = entity.PassengerId;

        dbContext.SaveChanges();
        return existingEntity;
    }

    public bool Delete(int id)
    {
        var existingEntity = dbContext.Tickets.Find(id);

        if (existingEntity == null)
        {
            return false;
        }

        dbContext.Tickets.Remove(existingEntity);
        dbContext.SaveChanges();

        return true;
    }
}