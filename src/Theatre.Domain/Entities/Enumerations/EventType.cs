using Theatre.Domain.Common;

namespace Theatre.Domain.Entities.Enumerations;

public class EventType : Enumeration
{
    public static EventType Drama = new(1, nameof(Drama));
    public static EventType Comedy = new(2, nameof(Comedy));
    public static EventType Ballet = new(3, nameof(Ballet));
    public static EventType Musical = new(4, nameof(Musical));


    private EventType(int id, string name)
        : base(id, name)
    {
    }
}