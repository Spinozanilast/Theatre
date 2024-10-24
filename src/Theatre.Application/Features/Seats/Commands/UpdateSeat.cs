using ErrorOr;
using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities.Enumerations;

namespace Theatre.Application.Features.Seats.Commands;

public record UpdateSeatCommand(int Id, int HallId, int SectorId, int Row, int Number, SeatType SeatType): ICommand<ErrorOr<Success>>;

public class UpdateSeatCommandHandler(ISeatsRepository seatsRepository): ICommandHandler<UpdateSeatCommand, ErrorOr<Success>>
{
    public async ValueTask<ErrorOr<Success>> Handle(UpdateSeatCommand request, CancellationToken cn = default)
    {
        var seat = await seatsRepository.GetByIdAsync(request.Id);
        if (seat is null)
        {
            return Error.NotFound("Seat not found");
        }

        seat.Update(request.HallId, request.SectorId, request.Row, request.Number, request.SeatType);
        await seatsRepository.UpdateAsync(seat);
        return Result.Success;
    }
}