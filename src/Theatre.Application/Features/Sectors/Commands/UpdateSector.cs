using ErrorOr;
using Mediator;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Sectors.Commands;

public record UpdateSectorCommand(int Id, int HallId, int RowsCount, int SeatsNum): ICommand<ErrorOr<Success>>;

public class UpdateSectorCommandHandler(ISectorsRepository sectorsRepository): ICommandHandler<UpdateSectorCommand, ErrorOr<Success>>
{
    public async ValueTask<ErrorOr<Success>> Handle(UpdateSectorCommand request, CancellationToken cn = default)
    {
        var sector = await sectorsRepository.GetByIdAsync(request.Id);
        if (sector is null)
        {
            return Error.NotFound("Sector not found");
        }

        sector.Update(request.HallId, request.RowsCount, request.SeatsNum);
        await sectorsRepository.UpdateAsync(sector);
        return Result.Success;
    }
}