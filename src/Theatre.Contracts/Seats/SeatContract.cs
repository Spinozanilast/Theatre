using Theatre.Domain.Entities.Enumerations;

namespace Theatre.Contracts.Seats;

public record SeatContract(int HallId, int SectorId, int RowNumber, int SeatNumber, SeatType SeatType);