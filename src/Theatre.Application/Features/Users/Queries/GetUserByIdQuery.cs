using ErrorOr;
using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Queries;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Users.Queries;

public record GetUserByIdQuery(Guid Id): IReturnType<ErrorOr<User>>;

public class GetUserByIdQueryHandlerWithCancellation(IUsersRepository usersRepository) : IQueryHandlerWithCancellation<GetUserByIdQuery, ErrorOr<User>>, IHandler
{
    public async Task<ErrorOr<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await usersRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user is null)
        {
            return Error.NotFound(description: "User not found");
        }

        return user;
    }
}