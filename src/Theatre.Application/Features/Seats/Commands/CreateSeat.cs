using ErrorOr;
using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;
using Theatre.Domain.Entities.Enums;

namespace Theatre.Application.Features.Seats.Commands;

public record CreateSeatCommand(short HallId, short SectorId, short Row, short Number, SeatType SeatType);

public class CreateSeatCommandHandler(ISeatsRepository seatsRepository)
    : ICommandHandler<CreateSeatCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
    {
        var seat = new Seat(request.HallId, request.SectorId, request.Row, request.Number, request.SeatType);
        await seatsRepository.CreateAsync(seat);
        return Result.Success;
    }
}