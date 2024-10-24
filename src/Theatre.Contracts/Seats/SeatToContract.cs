using Theatre.Domain.Entities;

namespace Theatre.Contracts.Seats;

public static class SeatToContract
{
    public static SeatContract ToContract(this Seat seat)
    {
        return new SeatContract(seat.HallId, seat.SectorId, seat.RowNumber, seat.SeatNumber, seat.SeatType);
    }
}