using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Sectors.Queries;

public record GetSectorsByHallIdQuery(int HallId): IQuery<List<Sector>>;

public class GetSectorsByHallIdQueryHandler(ISectorsRepository sectorsRepository)
    : IQueryHandler<GetSectorsByHallIdQuery, List<Sector>>
{
    public async ValueTask<List<Sector>> Handle(GetSectorsByHallIdQuery query, CancellationToken cn = default)
    {
        return await sectorsRepository.GetSectorsByHallId(query.HallId);
    }
}