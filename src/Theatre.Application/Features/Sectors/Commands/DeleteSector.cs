using Mediator;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Sectors.Commands;

public record DeleteSectorCommand(int SectorId): ICommand;

public class DeleteSectorCommandHandler(ISectorsRepository sectorsRepository): ICommandHandler<DeleteSectorCommand>
{
    public async ValueTask<Unit> Handle(DeleteSectorCommand request, CancellationToken cn = default)
    {
        await sectorsRepository.DeleteAsync(request.SectorId);
        return Unit.Value;
    }
}