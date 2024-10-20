
using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Seats.Queries;

public record GetSeatsByHallIdCommand(short HallId);

public class GetSeatsByHallIdCommandHandler(ISeatsRepository seatsRepository)
    : ICommandHandler<GetSeatsByHallIdCommand, IList<Seat>>
{
    public async Task<IList<Seat>> Handle(GetSeatsByHallIdCommand request, CancellationToken cancellationToken)
    {
        return await seatsRepository.GetSeatsByHallIdAsync(request.HallId);
    }
}