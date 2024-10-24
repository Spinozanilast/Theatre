using System.Drawing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Theatre.Application.Features.Users.Commands;
using Theatre.Application.Features.Users.Queries;
using Theatre.Contracts.Users;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Queries;

namespace Theatre.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ICommandDispatcherWithCancellation _commandDispatcher;
    private readonly IQueryDispatcherWithCancellation _queryDispatcher;

    public UsersController(ICommandDispatcherWithCancellation commandDispatcher,
        IQueryDispatcherWithCancellation queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserContract))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
    {
        var result = await _commandDispatcher.Dispatch(command, cancellationToken);
        return CreatedAtAction(nameof(Get), new { userId = result.Id }, result.ToResponse());
    }

    [Authorize(Policy = "Admin")]
    [HttpDelete("{userId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Remove([FromRoute] Guid userId, CancellationToken cancellationToken)
    {
        var deleteUserByIdCommand = new RemoveUserCommand(userId);
        await _commandDispatcher.Dispatch(deleteUserByIdCommand, cancellationToken);
        return NoContent();
    }

    [HttpGet("{userId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserContract))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] Guid userId, CancellationToken cancellationToken)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var result = await _queryDispatcher.Dispatch(getUserByIdQuery, cancellationToken);
        return result.Match<IActionResult>(
            user => Ok(),
            NotFound);
    }

    [HttpGet("by-phone")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserContract))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromBody] string phoneNumber, CancellationToken cancellationToken)
    {
        var getUserByphoneNumberQuery = new GetUserByPhoneNumberQuery(phoneNumber);
        var result = await _queryDispatcher.Dispatch(getUserByphoneNumberQuery, cancellationToken);
        return result.Match<IActionResult>(
            user => Ok(),
            NotFound);
    }
}