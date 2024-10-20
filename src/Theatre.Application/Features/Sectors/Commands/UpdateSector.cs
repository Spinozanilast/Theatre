using ErrorOr;

using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Sectors.Commands;

public record UpdateSectorCommand(short Id, short HallId, short RowsCount, short SeatsNum);

public class UpdateSectorCommandHandler(ISectorsRepository sectorsRepository)
    : ICommandHandler<UpdateSectorCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(UpdateSectorCommand request, CancellationToken cancellationToken)
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