namespace Theatre.Domain.Containers;

public class SectorWithRows
{
    public int SectorId { get; set; }
    public List<RowWithSeats> Rows { get; set; }
}