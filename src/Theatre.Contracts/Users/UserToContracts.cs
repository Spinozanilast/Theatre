using Theatre.Domain.Entities;

namespace Theatre.Contracts.Users;

public static class UserToContracts
{
    public static UserResponse ToResponse(this User user)
    {
        return new UserResponse(user.FirstName, user.Email, user.PhoneNumber, user.VisitedEventsCount);
    }
}