using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;

namespace Theatre.Application.Features.Sectors.Commands;

public record DeleteSectorCommand(int SectorId): IReturnType;

public class DeleteSectorCommandHandler(ISectorsRepository sectorsRepository) : ICommandHandler<DeleteSectorCommand>, IHandler
{
    public async Task Handle(DeleteSectorCommand request)
    {
        await sectorsRepository.DeleteAsync(request.SectorId);
    }
}