using Theatre.Domain.Common;

namespace Theatre.Domain.Entities;

public class User : Entity
{
    private readonly List<Guid> _remindersIds = [];

    public User(Guid id, string email, string phoneNumber, string firstName) : base(id)
    {
        Email = email;
        PhoneNumber = phoneNumber;
        FirstName = firstName;
    }

    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string FirstName { get; private set; }
    public int VisitedEventsCount { get; private set; } = 0;
    
    public void Update(string email, string phoneNumber, string firstName)
    {
        Email = email;
        PhoneNumber = phoneNumber;
        FirstName = firstName;
    }
}