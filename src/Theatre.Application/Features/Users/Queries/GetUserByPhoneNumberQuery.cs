using ErrorOr;
using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Users.Queries;

public record GetUserByPhoneNumberQuery(string PhoneNumber): IQuery<ErrorOr<User>>;

public class GetByPhoneNumberQueryHandlerWithCancellation(IUsersRepository usersRepository): IQueryHandler<GetUserByPhoneNumberQuery,ErrorOr<User>>
{
    public async ValueTask<ErrorOr<User>> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        var user = await usersRepository.GetByPhoneNumberAsync(request.PhoneNumber, cancellationToken);

        if (user is null)
        {
            return Error.NotFound(description: "User not found");
        }

        return user;
    }
}