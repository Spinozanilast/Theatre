using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Users.Commands;

public record RemoveUserCommand(Guid Id) : IRequest;

public class RemoveUserCommandHandler(IUsersRepository usersRepository) : IRequestHandler<RemoveUserCommand>
{
    public async Task Handle(RemoveUserCommand request, CancellationToken cancellationToken)
    {
        await usersRepository.RemoveAsync(request.Id, cancellationToken);
    }
}