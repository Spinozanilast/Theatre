using ErrorOr;
using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Users.Queries;

public record GetUserByIdQuery(Guid Id): IQuery<ErrorOr<User>>;

public class GetUserByIdQueryHandlerWithCancellation(IUsersRepository usersRepository)
    : IQueryHandler<GetUserByIdQuery, ErrorOr<User>>
{
    public async ValueTask<ErrorOr<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await usersRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user is null)
        {
            return Error.NotFound(description: "User not found");
        }

        return user;
    }
}