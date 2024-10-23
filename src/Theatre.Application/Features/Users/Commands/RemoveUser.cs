using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;

namespace Theatre.Application.Features.Users.Commands;

public record RemoveUserCommand(Guid Id): IReturnType;

public class RemoveUserCommandHandler(IUsersRepository usersRepository) : ICommandHandlerWithCancellation<RemoveUserCommand>, IHandler
{
    public async Task Handle(RemoveUserCommand request, CancellationToken cancellationToken)
    {
        await usersRepository.RemoveAsync(request.Id, cancellationToken);
    }
}