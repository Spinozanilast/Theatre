namespace Theatre.Contracts.Tickets;

public record TicketContract(
    Guid EventId,
    Guid UserId,
    int HallId,
    int SectorId,
    int RowNumber,
    int SeatNumber,
    decimal Price,
    DateTime EndsAt,
    DateTime StartsAt);