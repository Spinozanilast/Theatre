using ErrorOr;
using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Users.Queries;

public record GetByPhoneNumber(string PhoneNumber);

public class GetByPhoneNumberQueryHandler(IUsersRepository usersRepository)
    : IQueryHandler<GetByPhoneNumber, ErrorOr<User>>
{
    public async Task<ErrorOr<User>> Handle(GetByPhoneNumber request, CancellationToken cancellationToken)
    {
        var user = await usersRepository.GetByPhoneNumberAsync(request.PhoneNumber, cancellationToken);

        if (user is null)
        {
            return Error.NotFound(description: "User not found");
        }

        return user;
    }
}