using Airlines.Dto;
using Airlines.Domain;
using Airlines.Domain.Repositories;

namespace Airlines.Application.Services;

public class PassengerService(IRepository<Passenger> repository)
{
    private static Passenger MapDto(PassengerCreateDto entity)
    {
        return new Passenger
        {
            Id = 0,
            NumberOfPassport = entity.NumberOfPassport,
            FullName = entity.FullName,
            BirthDate = entity.BirthDate
        };
    }

    private static PassengerReadDto MapReadDto(Passenger entity) =>
        new(entity.Id, entity.NumberOfPassport, entity.FullName, entity.BirthDate);

    public int CreatePassenger(PassengerCreateDto entity) =>
        repository.Create(MapDto(entity));

    public List<PassengerReadDto> GetPassengers() =>
        repository.Read().Select(MapReadDto).ToList();

    public PassengerReadDto? GetPassenger(int id)
    {
        var entity = repository.Read(id);

        if (entity == null)
            return null;
        else
            return MapReadDto(entity);
    }

    public Passenger? UpdatePassenger(int id, PassengerCreateDto entity) =>
        repository.Update(id, MapDto(entity));

    public bool DeletePassenger(int id) =>
        repository.Delete(id);
}
