using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;
using Theatre.Domain.Entities.Enums;

namespace Theatre.Application.Seats.Commands;

public record CreateSeatCommand(short HallId, short SectorId, short Row, short Number, SeatType SeatType)
    : IRequest<ErrorOr<Success>>;

public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, ErrorOr<Success>>
{
    private readonly ISeatsRepository _seatsRepository;

    public CreateSeatCommandHandler(ISeatsRepository seatsRepository)
    {
        _seatsRepository = seatsRepository;
    }

    public async Task<ErrorOr<Success>> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
    {
        var seat = new Seat(request.HallId, request.SectorId, request.Row, request.Number, request.SeatType);
        await _seatsRepository.CreateAsync(seat);
        return Result.Success;
    }
}