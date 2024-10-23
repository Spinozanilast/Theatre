using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Queries;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Sectors.Queries;

public record GetSectorsByHallIdQuery(int HallId): IReturnType<IList<Sector>>;

public class GetSectorsByHallIdQueryHandler(ISectorsRepository sectorsRepository)
    : IQueryHandler<GetSectorsByHallIdQuery, IList<Sector>>
{
    public async Task<IList<Sector>> Handle(GetSectorsByHallIdQuery query)
    {
        return await sectorsRepository.GetSectorsByHallId(query.HallId);
    }
}