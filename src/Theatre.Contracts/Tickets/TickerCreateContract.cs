namespace Theatre.Contracts.Tickets;

public record TicketCreateContract(
    Guid EventId,
    int HallId,
    int[] SeatIds,
    decimal Price,
    DateTime EndsAt,
    DateTime StartsAt,
    DateTime BookingTime
);