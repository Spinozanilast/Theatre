using Theatre.Domain.Common;

namespace Theatre.Domain.Entities.Enumerations;

public class UserRoles : Enumeration
{
    public static SeatType User = new(1, nameof(User));
    public static SeatType Admin = new(2, nameof(Admin));

    public UserRoles(int id, string name) : base(id, name)
    {
    }
}