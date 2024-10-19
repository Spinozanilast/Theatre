using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Sectors.Queries;

public record GetSectorByIdCommand(short SectorId) : IRequest<ErrorOr<Sector>>;

public class GetSectorByIdCommandHandler : IRequestHandler<GetSectorByIdCommand, ErrorOr<Sector>>
{
    private readonly ISectorsRepository _sectorsRepository;

    public GetSectorByIdCommandHandler(ISectorsRepository sectorsRepository)
    {
        _sectorsRepository = sectorsRepository;
    }

    public async Task<ErrorOr<Sector>> Handle(GetSectorByIdCommand request, CancellationToken cancellationToken)
    {
        var sector = await _sectorsRepository.GetByIdAsync(request.SectorId);
        if (sector is null)
        {
            return Error.NotFound($"Sector with id {request.SectorId} not found");
        }

        return sector;
    }
}