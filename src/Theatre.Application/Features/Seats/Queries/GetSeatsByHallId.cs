using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Containers;

namespace Theatre.Application.Features.Seats.Queries;

public record GetSeatsByHallIdQuery(int HallId): IQuery<List<SectorWithRows>>;

public class GetSeatsByHallIdQueryHandler(ISeatsRepository seatsRepository): IQueryHandler<GetSeatsByHallIdQuery, List<SectorWithRows>>
{
    public async ValueTask<List<SectorWithRows>> Handle(GetSeatsByHallIdQuery request, CancellationToken cn = default)
    {
        return await seatsRepository.GetSeatsByHallIdAsync(request.HallId);
    }
}