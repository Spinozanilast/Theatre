using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Sectors.Commands;

public record DeleteSectorCommand(short SectorId) : IRequest;

public class DeleteSectorCommandHandler : IRequestHandler<DeleteSectorCommand>
{
    private readonly ISectorsRepository _sectorsRepository;

    public DeleteSectorCommandHandler(ISectorsRepository sectorsRepository)
    {
        _sectorsRepository = sectorsRepository;
    }

    public async Task Handle(DeleteSectorCommand request, CancellationToken cancellationToken)
    {
        await _sectorsRepository.DeleteAsync(request.SectorId);
    }
}