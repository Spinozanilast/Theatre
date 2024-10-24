using ErrorOr;
using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Sectors.Commands;

public record CreateSectorCommand(int HallId, int RowsCount, int SeatsNum): ICommand<ErrorOr<Sector>>;

public class CreateSectorCommandHandler(ISectorsRepository sectorsRepository): ICommandHandler<CreateSectorCommand, ErrorOr<Sector>>
{
    public async ValueTask<ErrorOr<Sector>> Handle(CreateSectorCommand request, CancellationToken cn = default)
    {
        var sector = new Sector(request.HallId, request.RowsCount, request.SeatsNum);
        await sectorsRepository.CreateAsync(sector);
        return sector;
    }
}