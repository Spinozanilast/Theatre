using Theatre.Domain.Common;

namespace Theatre.Domain.Entities;

public class Hall : AutoIncrementedEntity<int>
{
    public Hall(int seatsNumber, string hallName, int schemeGridRowsCount, int schemeGridColumnsCount)
    {
        SeatsNumber = seatsNumber;
        HallName = hallName;
        SchemeGridRowsCount = schemeGridRowsCount;
        SchemeGridColumnsCount = schemeGridColumnsCount;
    }

    public int SeatsNumber { get; private set; }
    public string HallName { get; private set; }
    
    public int SchemeGridRowsCount { get; private set; }
    public int SchemeGridColumnsCount { get; private set; }
    
    public void Update(int seatsNum, string hallName)
    {
        SeatsNumber = seatsNum;
        HallName = hallName;
    }
}