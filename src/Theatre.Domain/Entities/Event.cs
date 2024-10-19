using Theatre.Domain.Common;
using Theatre.Domain.Entities.Enums;

namespace Theatre.Domain.Entities;

public class Event : Entity
{
    public Event(Guid id, string name, DateTime dateTime, short hallId, decimal price, bool eventState,
        EventType eventType, IEnumerable<string>? directors, IEnumerable<string>? screenWriters,
        IEnumerable<string>? actors) : base(id)
    {
        Name = name;
        DateTime = dateTime;
        HallId = hallId;
        Price = price;
        EventState = eventState;
        Directors = directors;
        ScreenWriters = screenWriters;
        Actors = actors;
        EventType = eventType;
    }

    public IEnumerable<string>? Directors { get; private set; }
    public IEnumerable<string>? ScreenWriters { get; private set; }
    public IEnumerable<string>? Actors { get; private set; }
    public string Name { get; private set; }
    public EventType EventType { get; private set; }
    public DateTime DateTime { get; private set; }
    public short HallId { get; private set; }
    public decimal Price { get; private set; }
    public bool EventState { get; private set; }

    public void Update(string name, string description, DateTime dateTime, short hallId, decimal price,
        EventType eventType,
        IEnumerable<string>? directors, IEnumerable<string>? screenWriters, IEnumerable<string>? actors)
    {
        Name = name;
        DateTime = dateTime;
        HallId = hallId;
        Price = price;
        Directors = directors;
        ScreenWriters = screenWriters;
        Actors = actors;
        EventType = eventType;
    }
}