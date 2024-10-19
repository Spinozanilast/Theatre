using Theatre.Domain.Common;
using Theatre.Domain.Entities.Enums;

namespace Theatre.Domain.Entities;

public class Seat : AutoIncrementedEntity<int>, IUniqueSeatIndex<short>
{
    public Seat(
        
        short hallId, short sectorId, short rowNumber, short seatNumber, SeatType seatType)
    {
        HallId = hallId;
        SectorId = sectorId;
        RowNumber = rowNumber;
        SeatNumber = seatNumber;
        SeatType = seatType;
    }

    public short HallId { get; private set; }
    public short SectorId { get; private set; }
    public short RowNumber { get; private set; }
    public short SeatNumber { get; private set; }
    public SeatType SeatType { get; private set; }
    
    public void Update(short hallId, short sectorId, short rowNumber, short seatNumber, SeatType seatType)
    {
        HallId = hallId;
        SectorId = sectorId;
        RowNumber = rowNumber;
        SeatNumber = seatNumber;
        SeatType = seatType;
    }
}