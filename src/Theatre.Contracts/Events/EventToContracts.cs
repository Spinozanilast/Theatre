using Theatre.Domain.Entities;

namespace Theatre.Contracts.Events;

public static class EventToContracts
{
    public static EventContract ToResponse(this Event @event)
    {
        return new EventContract(@event.Name, @event.Description, @event.DateTime, @event.EventType,
            @event.HallId,
            @event.Price, @event.EventCast, @event.EventState);
    }
}