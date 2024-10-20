using ErrorOr;
using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Sectors.Commands;

public record CreateSectorCommand(short HallId, short RowsCount, short SeatsNum);

public class CreateSectorCommandHandler(ISectorsRepository sectorsRepository)
    : ICommandHandler<CreateSectorCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(CreateSectorCommand request, CancellationToken cancellationToken)
    {
        var sector = new Sector(request.HallId, request.RowsCount, request.SeatsNum);
        await sectorsRepository.CreateAsync(sector);
        return Result.Success;
    }
}