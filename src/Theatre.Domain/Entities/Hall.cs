using Theatre.Domain.Common;

namespace Theatre.Domain.Entities;

public class Hall : AutoIncrementedEntity<int>
{
    public Hall(int seatsNumber, string hallName)
    {
        SeatsNumber = seatsNumber;
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