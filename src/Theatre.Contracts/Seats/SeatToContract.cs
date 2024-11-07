using Theatre.Domain.Entities;

namespace Theatre.Contracts.Seats;

public static class SeatToContract
{
    public static SeatContract ToContract(this Seat seat)
    {
        return new SeatContract(seat.Id, seat.RowId, seat.SeatNumber, seat.SeatTypeMultiplier.SeatType, seat.SeatTypeMultiplier.Multiplier, seat.IsOccupied);
    }
}