using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Users.Commands;

public record CreateUserCommand(string Email, string PhoneNumber, string FirstName) : ICommand<User>;

public class CreateUserCommandHandler(IUsersRepository usersRepository) : ICommandHandler<CreateUserCommand, User>
{
    public async ValueTask<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(Guid.NewGuid(), request.Email, request.PhoneNumber, request.FirstName);
        await usersRepository.CreateAsync(user, cancellationToken);
        return user;
    }
}