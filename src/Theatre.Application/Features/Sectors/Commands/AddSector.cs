using ErrorOr;
using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Sectors.Commands;

public record CreateSectorCommand(short HallId, short RowsCount, short SeatsNum): IReturnType<ErrorOr<Success>>;

public class CreateSectorCommandHandler(ISectorsRepository sectorsRepository)
    : ICommandHandler<CreateSectorCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(CreateSectorCommand request)
    {
        var sector = new Sector(request.HallId, request.RowsCount, request.SeatsNum);
        await sectorsRepository.CreateAsync(sector);
        return Result.Success;
    }
}