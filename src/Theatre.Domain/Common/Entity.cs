namespace Theatre.Domain.Common;

public class Entity
{
    protected Entity(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}