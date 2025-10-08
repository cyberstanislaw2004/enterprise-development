namespace Airlines.Domain.Repositories;

public interface IPassengerRepository
{
    public int Create(Passenger entity);

    public List<Passenger> Read();

    public Passenger? Read(int id);

    public Passenger? Update(int id, Passenger entity);

    public bool Delete(int id);
}
