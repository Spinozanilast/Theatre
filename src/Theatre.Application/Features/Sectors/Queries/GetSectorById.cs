using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Sectors.Queries;

public record GetSectorByIdCommand(short SectorId) : IRequest<ErrorOr<Sector>>;

public class GetSectorByIdCommandHandler(ISectorsRepository sectorsRepository)
    : IRequestHandler<GetSectorByIdCommand, ErrorOr<Sector>>
{
    public async Task<ErrorOr<Sector>> Handle(GetSectorByIdCommand request, CancellationToken cancellationToken)
    {
        var sector = await sectorsRepository.GetByIdAsync(request.SectorId);
        if (sector is null)
        {
            return Error.NotFound($"Sector with id {request.SectorId} not found");
        }

        return sector;
    }
}