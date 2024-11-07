using Theatre.Domain.Common;
using Theatre.Domain.Entities.Special;

namespace Theatre.Domain.Entities;

public class Ticket : Entity
{
    public Ticket(Guid id, Guid eventId, Guid userId, int hallId, int[] seatIds,
        decimal price, DateTime endsAt, DateTime startsAt, DateTime bookingTime) : base(id)
    {
        EventId = eventId;
        UserId = userId;
        HallId = hallId;
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
    
    public int[] SeatIds { get; set; }
    public decimal Price { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime EndsAt { get; set; }

    public DateTime BookingTime { get; set; }

    public bool IsPaid { get; } = false;
    public bool IsCancelled { get; } = false;
    public DateTime? CancelledAt { get; } = null;
    public string? CancellationReason { get; } = string.Empty;

    public bool IsExpired => DateTime.UtcNow > EndsAt;

    public void Update(Guid eventId, Guid userId, DateTime endsAt, int hallId, decimal price)
    {
        EventId = eventId;
        UserId = userId;
        EndsAt = endsAt;
        HallId = hallId;
        Price = price;
    }
}