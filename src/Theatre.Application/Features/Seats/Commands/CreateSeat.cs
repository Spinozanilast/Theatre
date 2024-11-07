using ErrorOr;
using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;
using Theatre.Domain.Entities.Special;

namespace Theatre.Application.Features.Seats.Commands;

public record CreateSeatCommand(int RowId, int Number, SeatTypeMultiplier SeatTypeMultiplier)
    : ICommand<ErrorOr<Seat>>;

public class CreateSeatCommandHandler(ISeatsRepository seatsRepository)
    : ICommandHandler<CreateSeatCommand, ErrorOr<Seat>>
{
    public async ValueTask<ErrorOr<Seat>> Handle(CreateSeatCommand request, CancellationToken cn = default)
    {
        var seat = new Seat(request.RowId, request.Number, request.SeatTypeMultiplier);
        await seatsRepository.CreateAsync(seat);
        return seat;
    }
}