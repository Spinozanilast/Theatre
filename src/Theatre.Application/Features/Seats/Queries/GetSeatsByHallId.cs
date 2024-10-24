using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Seats.Queries;

public record GetSeatsByHallIdQuery(int HallId): IQuery<List<Seat>>;

public class GetSeatsByHallIdQueryHandler(ISeatsRepository seatsRepository): IQueryHandler<GetSeatsByHallIdQuery, List<Seat>>
{
    public async ValueTask<List<Seat>> Handle(GetSeatsByHallIdQuery request, CancellationToken cn = default)
    {
        return await seatsRepository.GetSeatsByHallIdAsync(request.HallId);
    }
}