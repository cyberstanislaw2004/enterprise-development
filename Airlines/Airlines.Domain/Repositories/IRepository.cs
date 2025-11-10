namespace Airlines.Domain.Repositories;

public interface IRepository<TEntity>
{
    public int Create(TEntity entity);
    public List<TEntity> Read();
    public TEntity? Read(int id);
    public TEntity? Update(int id, TEntity entity);
    public bool Delete(int id);
}