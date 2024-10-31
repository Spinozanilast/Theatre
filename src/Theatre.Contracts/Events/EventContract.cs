using Theatre.Domain.Entities.Enumerations;
using Theatre.Domain.Entities.Special;

namespace Theatre.Contracts.Events;

public record EventContract(
    string Name,
    string[] ImageUrls,
    string Description,
    DateTime DateTime,
    string EventType,
    int HallId,
    decimal Price,
    EventCast EventCast,
    bool EventState);