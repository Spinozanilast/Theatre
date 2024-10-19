using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Users.Queries;

public record GetByPhoneNumber(string PhoneNumber) : IRequest<ErrorOr<User>>;

public class GetByPhoneNumberQueryHandler : IRequestHandler<GetByPhoneNumber, ErrorOr<User>>
{
    private readonly IUsersRepository _usersRepository;

    public GetByPhoneNumberQueryHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<ErrorOr<User>> Handle(GetByPhoneNumber request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetByPhoneNumberAsync(request.PhoneNumber, cancellationToken);

        if (user is null)
        {
            return Error.NotFound(description: "User not found");
        }

        return user;
    }
}