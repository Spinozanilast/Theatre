using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.Domain.Entities;
using ErrorOr;
using Theatre.CqrsMediator.Queries;
using Theatre.CqrsMediator.Special;

namespace Theatre.Application.Features.Seats.Queries;

public record GetSeatByIdQuery(int SeatId) : IReturnType<ErrorOr<Seat>>;

public class GetSeatByIdQueryHandler(ISeatsRepository seatsRepository)
    : IQueryHandler<GetSeatByIdQuery, ErrorOr<Seat>>
{
    public async Task<ErrorOr<Seat>> Handle(GetSeatByIdQuery request)
    {
        var seat = await seatsRepository.GetByIdAsync(request.SeatId);

        if (seat is null)
        {
            Error.NotFound($"Seat with id: {request.SeatId} does not exist");
        }

        return seat;
    }
}