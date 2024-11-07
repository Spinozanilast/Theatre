using Theatre.Domain.Entities.Special;

namespace Theatre.Domain.Containers;

public class RowWithSeats
{
    public int RowId { get; set; }
    public List<SeatInfo> Seats { get; set; }
}