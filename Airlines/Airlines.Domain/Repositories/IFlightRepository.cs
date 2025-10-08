namespace Airlines.Domain.Repositories;

public interface IFlightRepository
{
    public int Create(Flight entity);

    public List<Flight> Read();

    public Flight? Read(int id);

    public Flight? Update(int id, Flight entity);

    public bool Delete(int id);
}
