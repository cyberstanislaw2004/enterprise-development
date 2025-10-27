namespace Airlines.Domain.Repositories;

public interface IAirplaneModelRepository
{
    public string Create(AirplaneModel entity);

    public List<AirplaneModel> Read();

    public AirplaneModel? Read(string id);

    public AirplaneModel? Update(string id, AirplaneModel entity);

    public bool Delete(string id);
}
