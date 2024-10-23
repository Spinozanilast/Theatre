using ErrorOr;
using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Sectors.Commands;

public record CreateSectorCommand(int HallId, int RowsCount, int SeatsNum): IReturnType<ErrorOr<Sector>>;

public class CreateSectorCommandHandler(ISectorsRepository sectorsRepository)
    : ICommandHandler<CreateSectorCommand, ErrorOr<Sector>>, IHandler
{
    public async Task<ErrorOr<Sector>> Handle(CreateSectorCommand request)
    {
        var sector = new Sector(request.HallId, request.RowsCount, request.SeatsNum);
        await sectorsRepository.CreateAsync(sector);
        return sector;
    }
}