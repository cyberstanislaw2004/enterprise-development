namespace Airlines.Domain.Repositories;

public interface ITicketRepository
{
    public string Create(Ticket entity);

    public List<Ticket> Read();

    public Ticket? Read(string id);

    public Ticket? Update(string id, Ticket entity);

    public bool Delete(string id);
}
