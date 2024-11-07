namespace Theatre.Contracts.Users;

public record UserContract(string Name, string Email, string PhoneNumber, int visitedEventsCount);