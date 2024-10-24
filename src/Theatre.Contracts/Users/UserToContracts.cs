using Theatre.Domain.Entities;

namespace Theatre.Contracts.Users;

public static class UserToContracts
{
    public static UserContract ToResponse(this User user)
    {
        return new UserContract(user.FirstName, user.Email, user.PhoneNumber, user.VisitedEventsCount);
    }
}