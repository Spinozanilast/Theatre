using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Seats.Queries;

public record GetSeatsBySectorIdCommand(short SectorId) : IRequest<IList<Seat>>;

public class GetSeatsBySectorIdCommandHandler(ISeatsRepository seatsRepository)
    : IRequestHandler<GetSeatsBySectorIdCommand, IList<Seat>>
{
    public async Task<IList<Seat>> Handle(GetSeatsBySectorIdCommand request, CancellationToken cancellationToken)
    {
        return await seatsRepository.GetSeatsBySectorIdAsync(request.SectorId);
    }
}