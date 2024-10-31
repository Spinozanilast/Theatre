using System.Collections.ObjectModel;
using Theatre.Domain.Common;

namespace Theatre.Domain.Entities;

public class Sector : AutoIncrementedEntity<int>
{
    public Sector(int hallId, int rowsCount, int seatsNum)
    {
        HallId = hallId;
        RowsCount = rowsCount;
        SeatsNum = seatsNum;
    }

    public int HallId { get; private set; }
    private Hall Hall { get; set; }
    public int RowsCount { get; private set; }
    public int SeatsNum { get; private set; }


    public void Update(int hallId, int rowsCount, int seatsNum)
    {
        HallId = hallId;
        RowsCount = rowsCount;
        SeatsNum = seatsNum;
    }
}