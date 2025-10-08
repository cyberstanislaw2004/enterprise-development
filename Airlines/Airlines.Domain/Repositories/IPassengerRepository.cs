namespace Airlines.Domain.Repositories;

public interface IPassengerRepository
{
    public string Create(Passenger entity);

    public List<Passenger> Read();

    public Passenger? Read(string id);

    public Passenger? Update(string id, Passenger entity);

    public bool Delete(string id);
}
