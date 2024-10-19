using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Users.Queries;

public record GetUserById(Guid Id) : IRequest<ErrorOr<User>>;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserById, ErrorOr<User>>
{
    private readonly IUsersRepository _usersRepository;

    public GetUserByIdQueryHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<ErrorOr<User>> Handle(GetUserById request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user is null)
        {
            return Error.NotFound(description: "User not found");
        }

        return user;
    }
}