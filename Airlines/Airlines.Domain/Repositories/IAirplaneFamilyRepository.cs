namespace Airlines.Domain.Repositories;

public interface IAirplaneFamilyRepository
{
    public string Create(AirplaneFamily entity);

    public List<AirplaneFamily> Read();

    public AirplaneFamily? Read(string id);

    public AirplaneFamily? Update(string id, AirplaneFamily entity);

    public bool Delete(string id);
}
