namespace Theatre.Domain.Entities.Special;

public class EventCast
{
    public EventCast(IEnumerable<string>? directors, IEnumerable<string>? screenWriters, IEnumerable<string>? actors)
    {
        Directors = directors;
        ScreenWriters = screenWriters;
        Actors = actors;
    }

    public IEnumerable<string>? Directors { get; protected set; }
    public IEnumerable<string>? ScreenWriters { get; protected set; }
    public IEnumerable<string>? Actors { get; protected set; }
}