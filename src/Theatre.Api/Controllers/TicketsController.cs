using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using Theatre.Application.Features.Tickets.Commands;
using Theatre.Application.Features.Tickets.Queries;
using Theatre.Contracts.Tickets;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Queries;

namespace Theatre.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketsController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public TicketsController(ICommandDispatcher commandDispatcher,
        IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TicketContract))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateTicket([FromBody] CreateTicketCommand command)
    {
        var result = await _commandDispatcher.Dispatch(command);
        return result.Match<IActionResult>(
            ticket => CreatedAtAction(nameof(GetTicketsByUserId), new { userId = ticket.UserId }, ticket.ToContract()),
            BadRequest);
    }

    [HttpDelete("{ticketId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteTicket([FromBody] Guid ticketId)
    {
        var deleteTicketCommand = new DeleteTicketCommand(ticketId);
        var result = await _commandDispatcher.Dispatch(deleteTicketCommand);
        return result.Match<IActionResult>(
            _ => NoContent(),
            BadRequest);
    }

    [HttpPut("{ticketId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateTicket([FromRoute] Guid ticketId, [FromBody] UpdateTicketCommand ticketEntity)
    {
        var updateTicketCommand = ticketEntity with { TicketId = ticketId };
        var result = await _commandDispatcher.Dispatch(updateTicketCommand);
        return result.Match<IActionResult>(
            _ => Ok(),
            NotFound
        );
    }

    [HttpGet("by-user/{userId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TicketContract>))]
    public async Task<IActionResult> GetTicketsByUserId([FromRoute] Guid userId)
    {
        var getTicketsByUserIdQuery = new GetTicketsByUserIdQuery(userId);
        var result = await _queryDispatcher.Dispatch(getTicketsByUserIdQuery);
        return Ok(result.Select(ticket => ticket.ToContract()).ToList());
    }
}