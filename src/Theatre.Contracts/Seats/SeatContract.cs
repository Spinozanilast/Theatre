namespace Theatre.Contracts.Seats;

public record SeatContract(int Id, int RowId, int SeatNumber, string SeatType, double PriceMultiplier, bool IsOccupied);