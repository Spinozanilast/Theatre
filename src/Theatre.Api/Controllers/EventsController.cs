using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Theatre.Application.Features.Events.Commands;
using Theatre.Application.Features.Events.Queries;
using Theatre.Contracts.Events;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Queries;
using Theatre.Domain.Common;
using Theatre.Domain.Entities.Enumerations;

namespace Theatre.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{
    private readonly ICommandDispatcherWithCancellation _commandDispatcher;
    private readonly IQueryDispatcherWithCancellation _queryDispatcher;

    public EventsController(ICommandDispatcherWithCancellation commandDispatcher,
        IQueryDispatcherWithCancellation queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EventContract))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateEventCommand command, CancellationToken cancellationToken)
    {
        if (Enumeration.TryFromName<EventType>(command.EventType.Name, out var eventType))
        {
            return BadRequest("Invalid event type");
        }

        var result = await _commandDispatcher.Dispatch(command, cancellationToken);
        return result.Match<IActionResult>(
            eventEntity => CreatedAtAction(nameof(Get), new { eventId = eventEntity.Id }, eventEntity.ToResponse()),
            BadRequest);
    }

    [Authorize]
    [HttpPut("{eventId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromRoute] Guid eventId, [FromBody] UpdateEventCommand eventEntity,
        CancellationToken cancellationToken)
    {
        var updateEventCommand = eventEntity with { EventId = eventId };
        await _commandDispatcher.Dispatch(updateEventCommand, cancellationToken);
        return Ok();
    }

    [Authorize]
    [HttpDelete("{eventId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Remove([FromRoute] Guid eventId, CancellationToken cancellationToken)
    {
        var deleteEventCommand = new DeleteEventCommand(eventId);
        await _commandDispatcher.Dispatch(deleteEventCommand, cancellationToken);
        return Ok();
    }

    [HttpGet("by-hall/{hallId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EventContract>))]
    public async Task<IActionResult> Get([FromRoute] int hallId, CancellationToken cancellationToken)
    {
        var getUserByIdQuery = new GetEventsByHallIdQuery(hallId);
        var events = await _queryDispatcher.Dispatch(getUserByIdQuery, cancellationToken);
        return Ok(events.Select(eventEntity => eventEntity.ToResponse()).ToList());
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EventContract>))]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var getAllEventsQuery = new GetAllEventsQuery();
        var events = await _queryDispatcher.Dispatch(getAllEventsQuery, cancellationToken);
        return Ok(events.Select(eventEntity => eventEntity.ToResponse()).ToList());
    }
}