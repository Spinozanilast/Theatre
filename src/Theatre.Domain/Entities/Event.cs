using Theatre.Domain.Common;
using Theatre.Domain.Entities.Enums;
using Theatre.Domain.Entities.Special;

namespace Theatre.Domain.Entities;

public class Event : Entity
{
    public Event(Guid id, string name, DateTime dateTime, short hallId, decimal price, bool eventState,
        EventType eventType, EventCast eventCast, string description) : base(id)
    {
        Name = name;
        DateTime = dateTime;
        HallId = hallId;
        Price = price;
        EventState = eventState;
        EventType = eventType;
        EventCast = eventCast;
        Description = description;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime DateTime { get; private set; }
    public EventType EventType { get; private set; }
    public short HallId { get; private set; }
    public decimal Price { get; private set; }
    public EventCast EventCast { get; private set; }
    public bool EventState { get; private set; }

    public void Update(string name, string description, DateTime dateTime, short hallId, decimal price,
        EventType eventType,
        EventCast eventCast)
    {
        Name = name;
        Description = description;
        DateTime = dateTime;
        HallId = hallId;
        Price = price;
        EventCast = eventCast;
        EventType = eventType;
    }
}