using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Sectors.Commands;

public record CreateSectorCommand(short HallId, short RowsCount, short SeatsNum) : IRequest<ErrorOr<Success>>;

public class CreateSectorCommandHandler(ISectorsRepository sectorsRepository)
    : IRequestHandler<CreateSectorCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(CreateSectorCommand request, CancellationToken cancellationToken)
    {
        var sector = new Sector(request.HallId, request.RowsCount, request.SeatsNum);
        await sectorsRepository.CreateAsync(sector);
        return Result.Success;
    }
}