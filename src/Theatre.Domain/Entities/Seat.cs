using Theatre.Domain.Common;
using Theatre.Domain.Entities.Enumerations;
using Theatre.Domain.Entities.Special;

namespace Theatre.Domain.Entities;

public class Seat : AutoIncrementedEntity<int>, IUniqueSeatIndex<int>
{
    public Seat(
        int hallId, int sectorId, int rowNumber, int seatNumber, SeatType seatType)
    {
        HallId = hallId;
        SectorId = sectorId;
        RowNumber = rowNumber;
        SeatNumber = seatNumber;
        SeatType = seatType;
    }

    public int HallId { get; private set; }
    private Hall Hall { get; set; }
    public int SectorId { get; private set; }
    private Sector Sector { get; set; }

    public int RowNumber { get; private set; }
    public int SeatNumber { get; private set; }
    public SeatType SeatType { get; private set; }

    public void Update(int hallId, int sectorId, int rowNumber, int seatNumber, SeatType seatType)
    {
        HallId = hallId;
        SectorId = sectorId;
        RowNumber = rowNumber;
        SeatNumber = seatNumber;
        SeatType = seatType;
    }
}