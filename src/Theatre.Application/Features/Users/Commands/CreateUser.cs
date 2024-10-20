using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Users.Commands;

public record CreateUserCommand(string Email, string PhoneNumber, string FirstName);

public class CreateUserCommandHandler(IUsersRepository usersRepository) : ICommandHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(Guid.NewGuid(), request.Email, request.PhoneNumber, request.FirstName);
        await usersRepository.CreateAsync(user, cancellationToken);
        return user.Id;
    }
}