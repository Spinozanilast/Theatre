using Theatre.Domain.Entities;

namespace Theatre.Contracts.Sectors;

public static class SectorToContract
{
    public static SectorContract ToContract(this Sector sector)
    {
        return new SectorContract(sector.HallId, sector.RowsCount, sector.SeatsNum);
    }
}