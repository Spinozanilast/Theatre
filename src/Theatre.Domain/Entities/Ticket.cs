using Theatre.Domain.Common;
using Theatre.Domain.Entities.Special;

namespace Theatre.Domain.Entities;

public class Ticket : Entity, IUniqueSeatIndex<short>
{
    public Ticket(Guid id, Guid eventId, Guid userId, short hallId, short sectorId, short rowNumber, short seatNumber,
        decimal price, DateTime endsAt) : base(id)
    {
        EventId = eventId;
        UserId = userId;
        HallId = hallId;
        SectorId = sectorId;
        RowNumber = rowNumber;
        SeatNumber = seatNumber;
        Price = price;
        EndsAt = endsAt;
    }

    public Guid EventId { get; set; }
    public Guid UserId { get; set; }
    public DateTime EndsAt { get; set; }
    public short HallId { get; set; }
    public short SectorId { get; set; }
    public short RowNumber { get; set; }
    public short SeatNumber { get; set; }
    public decimal Price { get; set; }

    public bool IsPaid { get; } = false;
    public bool IsCancelled { get; } = false;
    public DateTime? CancelledAt { get; } = null;
    public string? CancellationReason { get; } = string.Empty;

    public bool IsExpired => DateTime.UtcNow > EndsAt;

    public void Update(Guid eventId, Guid userId, DateTime endsAt, short hallId, short sectorId, short rowNumber,
        short seatNumber, decimal price)
    {
        EventId = eventId;
        UserId = userId;
        EndsAt = endsAt;
        HallId = hallId;
        SectorId = sectorId;
        RowNumber = rowNumber;
        SeatNumber = seatNumber;
        Price = price;
    }
}