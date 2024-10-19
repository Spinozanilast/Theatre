using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Sectors.Queries;

public record GetSectorsByHallIdCommand(short HallId) : IRequest<IList<Sector>>;

public class GetSectorsByHallIdCommandHandler : IRequestHandler<GetSectorsByHallIdCommand, IList<Sector>>
{
    private readonly ISectorsRepository _sectorsRepository;

    public GetSectorsByHallIdCommandHandler(ISectorsRepository sectorsRepository)
    {
        _sectorsRepository = sectorsRepository;
    }

    public async Task<IList<Sector>> Handle(GetSectorsByHallIdCommand request, CancellationToken cancellationToken)
    {
        return await _sectorsRepository.GetSectorsByHallId(request.HallId);
    }
}