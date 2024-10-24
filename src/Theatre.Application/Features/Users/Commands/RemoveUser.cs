using Mediator;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Users.Commands;

public record RemoveUserCommand(Guid Id): ICommand;

public class RemoveUserCommandHandler(IUsersRepository usersRepository): ICommandHandler<RemoveUserCommand>
{
    public async ValueTask<Unit> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
    {
        await usersRepository.RemoveAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}