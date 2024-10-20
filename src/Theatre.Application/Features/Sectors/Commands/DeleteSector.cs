
using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Sectors.Commands;

public record DeleteSectorCommand(short SectorId);

public class DeleteSectorCommandHandler(ISectorsRepository sectorsRepository) : ICommandHandler<DeleteSectorCommand>
{
    public async Task Handle(DeleteSectorCommand request, CancellationToken cancellationToken)
    {
        await sectorsRepository.DeleteAsync(request.SectorId);
    }
}