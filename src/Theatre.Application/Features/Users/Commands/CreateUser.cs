using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Users.Commands;

public record CreateUserCommand(string Email, string PhoneNumber, string FirstName): IReturnType<User>;

public class CreateUserCommandHandler(IUsersRepository usersRepository) : ICommandHandlerWithCancellation<CreateUserCommand, User>
{
    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(Guid.NewGuid(), request.Email, request.PhoneNumber, request.FirstName);
        await usersRepository.CreateAsync(user, cancellationToken);
        return user;
    }
}