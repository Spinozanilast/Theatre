using ErrorOr;
using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Users.Commands;

public record UpdateUserCommand(User UpdatedUser) : IReturnType<ErrorOr<Success>>;

public class UpdateUserCommandHandler(IUsersRepository usersRepository)
    : ICommandHandlerWithCancellation<UpdateUserCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await usersRepository.GetByIdAsync(request.UpdatedUser.Id, cancellationToken);

        if (user is not null)
        {
            return Error.NotFound(description: "User not found");
        }

        await usersRepository.UpdateAsync(request.UpdatedUser, cancellationToken);

        return Result.Success;
    }
}