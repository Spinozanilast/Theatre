using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Queries;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Seats.Queries;

public record GetSeatsByHallIdQuery(int HallId) : IReturnType<IList<Seat>>;

public class GetSeatsByHallIdQueryHandler(ISeatsRepository seatsRepository)
    : IQueryHandler<GetSeatsByHallIdQuery, IList<Seat>>, IHandler
{
    public async Task<IList<Seat>> Handle(GetSeatsByHallIdQuery request)
    {
        return await seatsRepository.GetSeatsByHallIdAsync(request.HallId);
    }
}