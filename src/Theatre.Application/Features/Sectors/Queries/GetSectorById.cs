using ErrorOr;
using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Sectors.Queries;

public record GetSectorByIdQuery(int SectorId): IQuery<ErrorOr<Sector>>;

public class GetSectorByIdQueryHandler(ISectorsRepository sectorsRepository): IQueryHandler<GetSectorByIdQuery, ErrorOr<Sector>>
{
    public async ValueTask<ErrorOr<Sector>> Handle(GetSectorByIdQuery request, CancellationToken cn = default)
    {
        var sector = await sectorsRepository.GetByIdAsync(request.SectorId);
        if (sector is null)
        {
            return Error.NotFound($"Sector with id {request.SectorId} not found");
        }

        return sector;
    }
}