using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Users.Commands;

public record UpdateUserCommand(User UpdatedUser)
    : IRequest<ErrorOr<Success>>;

public class UpdateUserCommandHandler(IUsersRepository usersRepository)
    : IRequestHandler<UpdateUserCommand, ErrorOr<Success>>
{
    private readonly IUsersRepository _usersRepository = usersRepository;

    public async Task<ErrorOr<Success>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetByIdAsync(request.UpdatedUser.Id, cancellationToken);

        if (user is not null)
        {
            return Error.NotFound(description: "User not found");
        }

        await _usersRepository.UpdateAsync(request.UpdatedUser, cancellationToken);

        return Result.Success;
    }
}