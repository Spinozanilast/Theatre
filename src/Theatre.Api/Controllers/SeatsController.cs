using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Theatre.Application.Features.Seats.Commands;
using Theatre.Application.Features.Seats.Queries;
using Theatre.Contracts.Seats;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Queries;

namespace Theatre.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SeatsController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public SeatsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SeatContract))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateSeatCommand commandEntity)
    {
        var result = await _commandDispatcher.Dispatch(commandEntity);
        return result.Match<IActionResult>(
            seat => CreatedAtAction(nameof(Get), new { hallId = seat.Id }, seat.ToContract()),
            BadRequest);
    }

    [Authorize]
    [HttpPut("{seatId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromRoute] int seatId, [FromBody] UpdateSeatCommand seatEntity)
    {
        var updateSeatCommand = seatEntity with { Id = seatId };
        await _commandDispatcher.Dispatch(updateSeatCommand);
        return Ok();
    }

    [Authorize]
    [HttpDelete("{seatId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Remove([FromRoute] int seatId)
    {
        var deleteSeatCommand = new DeleteSeatCommand(seatId);
        await _commandDispatcher.Dispatch(deleteSeatCommand);
        return Ok();
    }

    [HttpGet("{seatId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SeatContract))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] int seatId)
    {
        var getSeatById = new GetSeatByIdQuery(seatId);
        var result = await _queryDispatcher.Dispatch(getSeatById);
        return result.Match<IActionResult>(
            seat => Ok(seat.ToContract()),
            NotFound);
    }

    [HttpGet("by-sector/{sectorId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SeatContract>))]
    public async Task<IActionResult> GetBySectorId([FromRoute] int sectorId)
    {
        var getHallByIdQuery = new GetSeatsBySectorIdQuery(sectorId);
        var seats = await _queryDispatcher.Dispatch(getHallByIdQuery);
        return Ok(seats.Select(seat => seat.ToContract()).ToList());
    }

    [HttpGet("by-hall/{hallId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SeatContract>))]
    public async Task<IActionResult> GetByHallId([FromRoute] int hallId)
    {
        var getSeatsByHallId = new GetSeatsByHallIdQuery(hallId);
        var seats = await _queryDispatcher.Dispatch(getSeatsByHallId);
        return Ok(seats.Select(seat => seat.ToContract()).ToList());
    }
}