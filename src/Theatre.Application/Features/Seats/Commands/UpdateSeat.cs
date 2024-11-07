using ErrorOr;
using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities.Special;

namespace Theatre.Application.Features.Seats.Commands;

public record UpdateSeatCommand(int Id, int RowId, int Number, SeatTypeMultiplier SeatTypeMultiplier): ICommand<ErrorOr<Success>>;

public class UpdateSeatCommandHandler(ISeatsRepository seatsRepository): ICommandHandler<UpdateSeatCommand, ErrorOr<Success>>
{
    public async ValueTask<ErrorOr<Success>> Handle(UpdateSeatCommand request, CancellationToken cn = default)
    {
        var seat = await seatsRepository.GetByIdAsync(request.Id);
        if (seat is null)
        {
            return Error.NotFound("Seat not found");
        }

        seat.Update(request.RowId, request.Number, request.SeatTypeMultiplier);
        await seatsRepository.UpdateAsync(seat);
        return Result.Success;
    }
}