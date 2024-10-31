using Theatre.Domain.Common;

namespace Theatre.Domain.Entities;

public class Row : AutoIncrementedEntity<int>
{
    public Row(
        int hallId, int sectorId, int seatsNumber)
    {
        HallId = hallId;
        SectorId = sectorId;
        SeatsNumber = seatsNumber;
    }

    public int HallId { get; private set; }
    private Hall Hall { get; set; }
    public int SectorId { get; private set; }
    private Sector Sector { get; set; }

    public int SeatsNumber { get; set; }

    public ICollection<Seat> Seats { get; set; } = new List<Seat>();
}