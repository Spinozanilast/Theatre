using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Users.Commands;

public record RemoveUserCommand(Guid Id);

public class RemoveUserCommandHandler(IUsersRepository usersRepository) : ICommandHandler<RemoveUserCommand>
{
    public async Task Handle(RemoveUserCommand request, CancellationToken cancellationToken)
    {
        await usersRepository.RemoveAsync(request.Id, cancellationToken);
    }
}