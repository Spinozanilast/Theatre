using Theatre.Domain.Entities;

namespace Theatre.Contracts.Events;

public static class EventToContracts
{
    public static EventContract ToResponse(this Event eventEntity)
    {
        return new EventContract(eventEntity.Name, eventEntity.ImageUrls, eventEntity.Description, eventEntity.DateTime,
            eventEntity.EventType.Name,
            eventEntity.HallId,
            eventEntity.Price, eventEntity.EventCast, eventEntity.EventState);
    }
}