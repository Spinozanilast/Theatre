using Theatre.Domain.Common;

namespace Theatre.Domain.Entities;

public class Hall : AutoIncrementedEntity<short>
{
    public Hall(int seatsNum, string hallName)
    {
        SeatsNumber = seatsNum;
        HallName = hallName;
    }

    public int SeatsNumber { get; private set; }
    public string HallName { get; private set; }
    
    public void Update(int seatsNum, string hallName)
    {
        SeatsNumber = seatsNum;
        HallName = hallName;
    }
}