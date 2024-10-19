using Theatre.Domain.Common;

namespace Theatre.Domain.Reminders;

public class Reminder: Entity
{
    public Reminder(Guid id) : base(id)
    {
    }
    
    public Guid UserId { get; }
}