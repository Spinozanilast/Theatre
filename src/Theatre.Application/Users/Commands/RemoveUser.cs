using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Users.Commands;

public record RemoveUserCommand(Guid Id) : IRequest;

public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand>
{
    private readonly IUsersRepository _usersRepository;

    public RemoveUserCommandHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task Handle(RemoveUserCommand request, CancellationToken cancellationToken)
    {
        await _usersRepository.RemoveAsync(request.Id, cancellationToken);
    }
}