using ErrorOr;
using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Users.Queries;

public record GetUserById(Guid Id);

public class GetUserByIdQueryHandler(IUsersRepository usersRepository) : IQueryHandler<GetUserById, ErrorOr<User>>
{
    public async Task<ErrorOr<User>> Handle(GetUserById request, CancellationToken cancellationToken)
    {
        var user = await usersRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user is null)
        {
            return Error.NotFound(description: "User not found");
        }

        return user;
    }
}