using Theatre.Domain.Entities;

namespace Theatre.Contracts.Halls;

public static class HallToContracts
{
    public static HallContract ToResponse(this Hall hall)
    {
        return new HallContract(hall.Id, hall.HallName, hall.SeatsNumber, hall.SchemeGridColumnsCount, hall.SchemeGridRowsCount);
    }
}