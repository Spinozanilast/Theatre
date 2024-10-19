using Theatre.Domain.Common;

namespace Theatre.Domain.Entities;

public class Sector : AutoIncrementedEntity<short>
{
    public Sector(short hallId, short rowsCount, short seatsNum)
    {
        HallId = hallId;
        RowsCount = rowsCount;
        SeatsNum = seatsNum;
    }
    
    public short HallId { get; private set; }
    public short RowsCount { get; private set; }
    public short SeatsNum { get; private set; }
    
    public void Update(short hallId, short rowsCount, short seatsNum)
    {
        HallId = hallId;
        RowsCount = rowsCount;
        SeatsNum = seatsNum;
    }
}