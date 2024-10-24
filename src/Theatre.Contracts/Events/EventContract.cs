﻿using Theatre.Domain.Entities.Enumerations;
using Theatre.Domain.Entities.Special;

namespace Theatre.Contracts.Events;

public record EventContract(
    string Name,
    string Description,
    DateTime DateTime,
    EventType EventType,
    int HallId,
    decimal Price,
    EventCast EventCast,
    bool EventState);