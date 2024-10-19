using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities.Enums;

namespace Theatre.Application.Features.Seats.Commands;

public record UpdateSeatCommand(short Id, short HallId, short SectorId, short Row, short Number, SeatType SeatType)
    : IRequest<ErrorOr<Success>>;

public class UpdateSeatCommandHandler(ISeatsRepository seatsRepository)
    : IRequestHandler<UpdateSeatCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
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