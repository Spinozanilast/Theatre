using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Seats.Queries;

public record GetSeatsBySectorIdQuery(int SectorId): IQuery<List<Seat>>;

public class GetSeatsBySectorIdQueryHandler(ISeatsRepository seatsRepository): IQueryHandler<GetSeatsBySectorIdQuery, List<Seat>>
{
    public async ValueTask<List<Seat>> Handle(GetSeatsBySectorIdQuery request, CancellationToken cn = default)
    {
        return await seatsRepository.GetSeatsBySectorIdAsync(request.SectorId);
    }
}