using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Theatre.Application.Common;
using Theatre.Application.Features.Users.Commands;
using Theatre.Application.Features.Users.Queries;
using Theatre.Contracts.Users;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Queries;
using Theatre.Domain.Entities;

namespace Theatre.Api.Controllers;

[ApiController]
public class UsersController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly ICommandDispatcherWithCancellation _commandDispatcherWithCancellation;
    private readonly IQueryDispatcher _queryDispatcher;

    public UsersController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
    {
        var result = await _commandDispatcher.Dispatch(command, cancellationToken);
        return CreatedAtAction(nameof(Get), new { userId = result.Id }, result.ToResponse());
    }

    [Authorize]
    [HttpDelete("{userId:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid userId)
    {
        var deleteUserByIdCommand = new RemoveUserCommand(userId);

        var result = await _commandDispatcher.Dispatch(deleteUserByIdCommand);
    }

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var result = await _queryDispatcher.Dispatch(getUserByIdQuery);
        result.Match<IActionResult>(
            user => Ok(),
            BadRequest);
    }
    
    
}