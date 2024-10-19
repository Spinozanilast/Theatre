using Theatre.Domain.Common;

namespace Theatre.Domain.Entities;

public class Ticket : Entity, IUniqueSeatIndex<short>
{
    public Ticket(Guid id, Guid eventId, Guid userId, short hallId, short sectorId, short rowNumber, short seatNumber,
        decimal endPrice, bool isBooked) : base(id)
    {
        EventId = eventId;
        UserId = userId;
        HallId = hallId;
        SectorId = sectorId;
        RowNumber = rowNumber;
        SeatNumber = seatNumber;
        EndPrice = endPrice;
    }

    public Guid EventId { get; }
    public Guid UserId { get; }
    public short HallId { get; }
    public short SectorId { get; }
    public short RowNumber { get; }
    public short SeatNumber { get; }
    public decimal EndPrice { get; }
    public bool IsBooked { get; private set; } = false;
}