namespace Airlines.Domain.Repositories;

public interface IAirplaneModelRepository
{
    public int Create(AirplaneModel entity);

    public List<AirplaneModel> Read();

    public AirplaneModel? Read(int id);

    public AirplaneModel? Update(int id, AirplaneModel entity);

    public bool Delete(int id);
}
