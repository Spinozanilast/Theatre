using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Theatre.Application.Features.Sectors.Commands;
using Theatre.Application.Features.Sectors.Queries;
using Theatre.Contracts.Sectors;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Queries;

namespace Theatre.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SectorsController : ControllerBase
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly ICommandDispatcher _commandDispatcher;

    public SectorsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SectorContract))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateSectorCommand createSectorCommand)
    {
        var result = await _commandDispatcher.Dispatch(createSectorCommand);
        return result.Match<IActionResult>(
            sector => CreatedAtAction(nameof(Get), new { sectorId = sector.Id }, sector.ToContract()),
            BadRequest);
    }

    [HttpDelete("{sectorId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete([FromRoute] int sectorId)
    {
        var deleteSectorCommand = new DeleteSectorCommand(sectorId);
        await _commandDispatcher.Dispatch(deleteSectorCommand);
        return NoContent();
    }

    [HttpPut("{sectorId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromRoute] int sectorId,
        [FromBody] UpdateSectorCommand sectorEntity)
    {
        var updateSectorCommand =
            sectorEntity with { Id = sectorId };
        var result = await _commandDispatcher.Dispatch(updateSectorCommand);
        return result.Match<IActionResult>(
            _ => Ok(),
            BadRequest);
    }


    [HttpGet("{sectorId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SectorContract))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] int sectorId)
    {
        var getSectorByIdQuery = new GetSectorByIdQuery(sectorId);
        var result = await _queryDispatcher.Dispatch(getSectorByIdQuery);
        return result.Match<IActionResult>(
            Ok,
            NotFound);
    }

    [HttpGet("by-hall/{hallId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SectorContract>))]
    public async Task<IActionResult> GetAllByHallId([FromRoute] int hallId)
    {
        var getSectorsByHallIdQuery = new GetSectorsByHallIdQuery(hallId);
        var sectors = await _queryDispatcher.Dispatch(getSectorsByHallIdQuery);
        return Ok(sectors.Select(sector => sector.ToContract()).ToList());
    }
}