using Theatre.Domain.Common;
using Theatre.Domain.Entities.Special;

namespace Theatre.Domain.Entities;

public class Ticket : Entity, IUniqueSeatIndex<int>
{
    public Ticket(Guid id, Guid eventId, Guid userId, int hallId, int sectorId, int rowNumber, int seatNumber,
        decimal price, DateTime endsAt, DateTime startsAt, DateTime bookingTime) : base(id)
    {
        EventId = eventId;
        UserId = userId;
        HallId = hallId;
        SectorId = sectorId;
        RowNumber = rowNumber;
        SeatNumber = seatNumber;
        Price = price;
        EndsAt = endsAt;
        StartsAt = startsAt;
        BookingTime = bookingTime;
    }

    public Guid EventId { get; set; }
    private Event Event { get; set; }
    public Guid UserId { get; set; }
    private User User { get; set; }
    public int HallId { get; set; }
    private Hall Hall { get; set; }
    public int SectorId { get; set; }
    private Sector Sector { get; set; }
    public int RowNumber { get; set; }
    public int SeatNumber { get; set; }
    public decimal Price { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime EndsAt { get; set; }

    public DateTime BookingTime { get; set; }

    public bool IsPaid { get; } = false;
    public bool IsCancelled { get; } = false;
    public DateTime? CancelledAt { get; } = null;
    public string? CancellationReason { get; } = string.Empty;

    public bool IsExpired => DateTime.UtcNow > EndsAt;

    public void Update(Guid eventId, Guid userId, DateTime endsAt, int hallId, int sectorId, int rowNumber,
        int seatNumber, decimal price)
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