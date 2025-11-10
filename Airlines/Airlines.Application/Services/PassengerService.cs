using Airlines.Application.Dto;
using Airlines.Domain;
using Airlines.Domain.Repositories;

namespace Airlines.Application.Services;

public class PassengerService(IPassengerRepository repository)
{
    private static Passenger MapDto(PassengerDto entity)
    {
        return new Passenger
        {
            Id = 0,
            NumberOfPassport = entity.NumberOfPassport,
            FullName = entity.FullName,
            BirthDate = entity.BirthDate
        };
    }

    public int CreatePassenger(PassengerDto entity)
    {
        return repository.Create(MapDto(entity));
    }

    public List<Passenger> GetPassengers()
    {
        return repository.Read();
    }

    public Passenger? GetPassenger(int id)
    {
        return repository.Read(id);
    }

    public Passenger? UpdatePassenger(int id, PassengerDto entity)
    {
        return repository.Update(id, MapDto(entity));
    }

    public bool DeletePassenger(int id)
    {
        return repository.Delete(id);
    }
}
