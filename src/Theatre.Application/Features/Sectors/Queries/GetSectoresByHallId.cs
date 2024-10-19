using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Sectors.Queries;

public record GetSectorsByHallIdCommand(short HallId) : IRequest<IList<Sector>>;

public class GetSectorsByHallIdCommandHandler(ISectorsRepository sectorsRepository)
    : IRequestHandler<GetSectorsByHallIdCommand, IList<Sector>>
{
    public async Task<IList<Sector>> Handle(GetSectorsByHallIdCommand request, CancellationToken cancellationToken)
    {
        return await sectorsRepository.GetSectorsByHallId(request.HallId);
    }
}