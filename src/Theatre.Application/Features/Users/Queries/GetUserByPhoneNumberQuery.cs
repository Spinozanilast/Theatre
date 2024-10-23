﻿using ErrorOr;
using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Queries;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Users.Queries;

public record GetUserByPhoneNumberQuery(string PhoneNumber): IReturnType<ErrorOr<User>>;

public class GetByPhoneNumberQueryHandlerWithCancellation(IUsersRepository usersRepository)
    : IQueryHandlerWithCancellation<GetUserByPhoneNumberQuery, ErrorOr<User>>, IHandler
{
    public async Task<ErrorOr<User>> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        var user = await usersRepository.GetByPhoneNumberAsync(request.PhoneNumber, cancellationToken);

        if (user is null)
        {
            return Error.NotFound(description: "User not found");
        }

        return user;
    }
}