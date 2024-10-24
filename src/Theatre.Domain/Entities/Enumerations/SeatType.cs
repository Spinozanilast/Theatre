using Theatre.Domain.Common;

namespace Theatre.Domain.Entities.Enumerations;

public class SeatType : Enumeration
{
    public static SeatType Standard = new(1, nameof(Standard));
    public static SeatType Premium = new(2, nameof(Premium));
    public static SeatType Vip = new(3, nameof(Vip));
    public static SeatType Pair = new(4, nameof(Pair));

    public SeatType(int id, string name) : base(id, name)
    {
    }
}