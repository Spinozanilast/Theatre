using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Sectors.Commands;

public record UpdateSectorCommand(short Id, short HallId, short RowsCount, short SeatsNum) : IRequest<ErrorOr<Success>>;

public class UpdateSectorCommandHandler : IRequestHandler<UpdateSectorCommand, ErrorOr<Success>>
{
    private readonly ISectorsRepository _sectorsRepository;

    public UpdateSectorCommandHandler(ISectorsRepository sectorsRepository)
    {
        _sectorsRepository = sectorsRepository;
    }

    public async Task<ErrorOr<Success>> Handle(UpdateSectorCommand request, CancellationToken cancellationToken)
    {
        var sector = await _sectorsRepository.GetByIdAsync(request.Id);
        if (sector is null)
        {
            return Error.NotFound("Sector not found");
        }

        sector.Update(request.HallId, request.RowsCount, request.SeatsNum);
        await _sectorsRepository.UpdateAsync(sector);
        return Result.Success;
    }
}