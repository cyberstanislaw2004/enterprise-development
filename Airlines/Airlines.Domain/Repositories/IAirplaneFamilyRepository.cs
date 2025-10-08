namespace Airlines.Domain.Repositories;

public interface IAirplaneFamilyRepository
{
    public int Create(AirplaneFamily entity);

    public List<AirplaneFamily> Read();

    public AirplaneFamily? Read(int id);

    public AirplaneFamily? Update(int id, AirplaneFamily entity);

    public bool Delete(int id);
}
