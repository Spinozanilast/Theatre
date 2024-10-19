﻿using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Users.Commands;

public record CreateUserCommand(string Email, string PhoneNumber, string FirstName) : IRequest<Guid>;

public class CreateUserCommandHandler(IUsersRepository usersRepository) : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUsersRepository _usersRepository = usersRepository;

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(Guid.NewGuid(), request.Email, request.PhoneNumber, request.FirstName);
        await _usersRepository.CreateAsync(user, cancellationToken);
        return user.Id;
    }
}