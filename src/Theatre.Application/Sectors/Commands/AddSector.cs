using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Sectors.Commands;

public record CreateSectorCommand(short HallId, short RowsCount, short SeatsNum) : IRequest<ErrorOr<Success>>;

public class CreateSectorCommandHandler : IRequestHandler<CreateSectorCommand, ErrorOr<Success>>
{
    private readonly ISectorsRepository _sectorsRepository;

    public CreateSectorCommandHandler(ISectorsRepository sectorsRepository)
    {
        _sectorsRepository = sectorsRepository;
    }

    public async Task<ErrorOr<Success>> Handle(CreateSectorCommand request, CancellationToken cancellationToken)
    {
        var sector = new Sector(request.HallId, request.RowsCount, request.SeatsNum);
        await _sectorsRepository.CreateAsync(sector);
        return Result.Success;
    }
}