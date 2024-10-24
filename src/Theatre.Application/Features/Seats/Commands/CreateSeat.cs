using ErrorOr;
using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;
using Theatre.Domain.Entities.Enumerations;

namespace Theatre.Application.Features.Seats.Commands;

public record CreateSeatCommand(int HallId, int SectorId, int Row, int Number, SeatType SeatType)
    : ICommand<ErrorOr<Seat>>;

public class CreateSeatCommandHandler(ISeatsRepository seatsRepository)
    : ICommandHandler<CreateSeatCommand, ErrorOr<Seat>>
{
    public async ValueTask<ErrorOr<Seat>> Handle(CreateSeatCommand request, CancellationToken cn = default)
    {
        var seat = new Seat(request.HallId, request.SectorId, request.Row, request.Number, request.SeatType);
        await seatsRepository.CreateAsync(seat);
        return seat;
    }
}