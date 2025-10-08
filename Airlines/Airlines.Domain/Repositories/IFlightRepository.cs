namespace Airlines.Domain.Repositories;

public interface IFlightRepository
{
    public string Create(Flight entity);

    public List<Flight> Read();

    public Flight? Read(string id);

    public Flight? Update(string id, Flight entity);

    public bool Delete(string id);
}
