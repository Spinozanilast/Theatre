using MediatR;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Sectors.Commands;

public record DeleteSectorCommand(short SectorId) : IRequest;

public class DeleteSectorCommandHandler(ISectorsRepository sectorsRepository) : IRequestHandler<DeleteSectorCommand>
{
    public async Task Handle(DeleteSectorCommand request, CancellationToken cancellationToken)
    {
        await sectorsRepository.DeleteAsync(request.SectorId);
    }
}