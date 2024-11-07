namespace Theatre.Contracts.Tickets;

public record TicketContract(
    Guid EventId,
    Guid UserId,
    int HallId,
    int[] SeatIds,
    decimal Price,
    DateTime EndsAt,
    DateTime StartsAt,
    DateTime BookingTime);