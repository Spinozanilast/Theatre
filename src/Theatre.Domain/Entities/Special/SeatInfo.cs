namespace Theatre.Domain.Entities.Special;

public class SeatInfo
{
    public int SeatId { get; set; }
    public int SeatNumber { get; set; }
    public bool IsOccupied { get; set; }
    public SeatTypeMultiplier SeatTypeMultiplier { get; set; }
}