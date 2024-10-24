using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Theatre.Application.Features.Halls.Commands;
using Theatre.Application.Features.Halls.Queries;
using Theatre.Contracts.Halls;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Queries;
using Theatre.Domain.Entities;

namespace Theatre.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HallsController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public HallsController(ICommandDispatcher commandDispatcher,
        IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(HallContract))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateHallCommand command)
    {
        var result = await _commandDispatcher.Dispatch(command);
        return result.Match<IActionResult>(
            hall => CreatedAtAction(nameof(Get), new { hallId = hall.Id }, hall.ToResponse()),
            BadRequest);
    }

    [Authorize]
    [HttpPut("{hallId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromRoute] int hallId, [FromBody] UpdateHallCommand hallEntity)
    {
        var updateHallCommand = hallEntity with { Id = hallId };
        await _commandDispatcher.Dispatch(updateHallCommand);
        return Ok();
    }

    [Authorize]
    [HttpDelete("{hallId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Remove([FromRoute] int hallId)
    {
        var deleteHallCommand = new DeleteHallCommand(hallId);
        await _commandDispatcher.Dispatch(deleteHallCommand);
        return Ok();
    }

    [HttpGet("{hallId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HallContract))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] int hallId)
    {
        var getHallByIdQuery = new GetHallByIdQuery(hallId);
        var result = await _queryDispatcher.Dispatch(getHallByIdQuery);
        return result.Match<IActionResult>(
            hall => Ok(hall.ToResponse()),
            NotFound);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HallContract>))]
    public async Task<IActionResult> Get()
    {
        var getAllHallsQuery = new GetAllHallsQuery();
        var halls = await _queryDispatcher.Dispatch(getAllHallsQuery);
        return Ok(halls.Select(hall => hall.ToResponse()).ToList());
    }
}