using ErrorOr;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Theatre.Application.Features.Sectors.Commands;
using Theatre.Application.Features.Sectors.Queries;
using Theatre.Contracts.Sectors;


namespace Theatre.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SectorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SectorsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SectorContract))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateSectorCommand createSectorCommand)
    {
        var result = await _mediator.Send(createSectorCommand);
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
        await _mediator.Send(deleteSectorCommand);
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
        var result = await _mediator.Send(updateSectorCommand);
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
        var result = await _mediator.Send(getSectorByIdQuery);
        return result.Match<IActionResult>(
            Ok,
            NotFound);
    }
    
    [HttpGet("by-hall/{hallId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SectorContract>))]
    public async Task<IActionResult> GetAllByHallId([FromRoute] int hallId)
    {
        var getSectorsByHallIdQuery = new GetSectorsByHallIdQuery(hallId);
        var sectors = await _mediator.Send(getSectorsByHallIdQuery);
        return Ok(sectors.Select(sector => sector.ToContract()).ToList());
    }
}