using Theatre.Domain.Common;

namespace Theatre.Domain.Entities;

public class Row : AutoIncrementedEntity<int>
{
    public Row(int hallId, int sectorId, int rowNumber, int seatsNumber)
    {
        HallId = hallId;
        SectorId = sectorId;
        RowNumber = rowNumber;
        SeatsNumber = seatsNumber;
    }

    public int HallId { get; private set; }
    public Hall Hall { get; set; }
    public int SectorId { get; private set; }
    public Sector Sector { get; set; }
    public int RowNumber { get; private set; }
    public int SeatsNumber { get; set; }
    public ICollection<Seat> Seats { get; set; } = new List<Seat>();
}