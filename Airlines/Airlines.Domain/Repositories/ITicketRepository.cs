namespace Airlines.Domain.Repositories;

public interface ITicketRepository
{
    public int Create(Ticket entity);

    public List<Ticket> Read();

    public Ticket? Read(int id);

    public Ticket? Update(int id, Ticket entity);

    public bool Delete(int id);
}
