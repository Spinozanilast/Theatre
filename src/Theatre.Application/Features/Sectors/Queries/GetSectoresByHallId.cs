
using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Sectors.Queries;

public record GetSectorsByHallIdCommand(short HallId);

public class GetSectorsByHallIdCommandHandler(ISectorsRepository sectorsRepository)
    : ICommandHandler<GetSectorsByHallIdCommand, IList<Sector>>
{
    public async Task<IList<Sector>> Handle(GetSectorsByHallIdCommand request, CancellationToken cancellationToken)
    {
        return await sectorsRepository.GetSectorsByHallId(request.HallId);
    }
}