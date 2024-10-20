
using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Seats.Queries;

public record GetSeatsBySectorIdCommand(short SectorId);

public class GetSeatsBySectorIdCommandHandler(ISeatsRepository seatsRepository)
    : ICommandHandler<GetSeatsBySectorIdCommand, IList<Seat>>
{
    public async Task<IList<Seat>> Handle(GetSeatsBySectorIdCommand request, CancellationToken cancellationToken)
    {
        return await seatsRepository.GetSeatsBySectorIdAsync(request.SectorId);
    }
}