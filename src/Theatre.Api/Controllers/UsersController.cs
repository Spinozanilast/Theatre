using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Theatre.Application.Features.Users.Commands;
using Theatre.Application.Features.Users.Queries;
using Theatre.Contracts.Users;

namespace Theatre.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserContract))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
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
        await _mediator.Send(deleteUserByIdCommand, cancellationToken);
        return NoContent();
    }

    [HttpGet("{userId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserContract))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] Guid userId, CancellationToken cancellationToken)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var result = await _mediator.Send(getUserByIdQuery, cancellationToken);
        return result.Match<IActionResult>(
            user => Ok(),
            NotFound);
    }

    [HttpGet("by-phone/{phoneNumber:required}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserContract))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] string phoneNumber, CancellationToken cancellationToken)
    {
        var getUserByphoneNumberQuery = new GetUserByPhoneNumberQuery(phoneNumber);
        var result = await _mediator.Send(getUserByphoneNumberQuery, cancellationToken);
        return result.Match<IActionResult>(
            user => Ok(),
            NotFound);
    }
}