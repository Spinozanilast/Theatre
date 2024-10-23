using ErrorOr;
using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;
using Theatre.Domain.Entities.Enumerations;

namespace Theatre.Application.Features.Seats.Commands;

public record CreateSeatCommand(int HallId, int SectorId, int Row, int Number, SeatType SeatType)
    : IReturnType<ErrorOr<Seat>>;

public class CreateSeatCommandHandler(ISeatsRepository seatsRepository)
    : ICommandHandler<CreateSeatCommand, ErrorOr<Seat>>, IHandler
{
    public async Task<ErrorOr<Seat>> Handle(CreateSeatCommand request)
    {
        var seat = new Seat(request.HallId, request.SectorId, request.Row, request.Number, request.SeatType);
        await seatsRepository.CreateAsync(seat);
        return seat;
    }
}