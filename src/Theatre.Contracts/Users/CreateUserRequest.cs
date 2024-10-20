namespace Theatre.Contracts.Users;

public record CreateUserRequest(string Name, string Email, string PhoneNumber);