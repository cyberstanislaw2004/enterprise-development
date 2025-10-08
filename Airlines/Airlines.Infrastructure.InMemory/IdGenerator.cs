namespace Airlines.Infrastructure.InMemory;

public class IdGenerator
{
    public static int IdNext<T>(IEnumerable<T> collection)
    {
        if (collection.Any() == false) return 1;

        return collection.Count() + 1;
    }
}