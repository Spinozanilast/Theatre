using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;
using ErrorOr;
using Mediator;

namespace Theatre.Application.Features.Seats.Queries;

public record GetSeatByIdQuery(int SeatId): IQuery<ErrorOr<Seat>>;

public class GetSeatByIdQueryHandler(ISeatsRepository seatsRepository): IQueryHandler<GetSeatByIdQuery, ErrorOr<Seat>>
{
    public async ValueTask<ErrorOr<Seat>> Handle(GetSeatByIdQuery request, CancellationToken cn = default)
    {
        var seat = await seatsRepository.GetByIdAsync(request.SeatId);

        if (seat is null)
        {
            Error.NotFound($"Seat with id: {request.SeatId} does not exist");
        }

        return seat;
    }
}