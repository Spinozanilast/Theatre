using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Queries;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Seats.Queries;

public record GetSeatsBySectorIdQuery(int SectorId) : IReturnType<IList<Seat>>;

public class GetSeatsBySectorIdQueryHandler(ISeatsRepository seatsRepository)
    : IQueryHandler<GetSeatsBySectorIdQuery, IList<Seat>>
{
    public async Task<IList<Seat>> Handle(GetSeatsBySectorIdQuery request)
    {
        return await seatsRepository.GetSeatsBySectorIdAsync(request.SectorId);
    }
}