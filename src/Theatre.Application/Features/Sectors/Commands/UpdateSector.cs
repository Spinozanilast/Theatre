using ErrorOr;
using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;

namespace Theatre.Application.Features.Sectors.Commands;

public record UpdateSectorCommand(int Id, int HallId, int RowsCount, int SeatsNum): IReturnType<ErrorOr<Success>>;

public class UpdateSectorCommandHandler(ISectorsRepository sectorsRepository)
    : ICommandHandler<UpdateSectorCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(UpdateSectorCommand request)
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