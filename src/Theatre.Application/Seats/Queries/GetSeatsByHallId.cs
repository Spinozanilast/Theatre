using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Seats.Queries;

public record GetSeatsByHallIdCommand(short HallId) : IRequest<IList<Seat>>;

public class GetSeatsByHallIdCommandHandler(ISeatsRepository seatsRepository)
    : IRequestHandler<GetSeatsByHallIdCommand, IList<Seat>>
{
    public async Task<IList<Seat>> Handle(GetSeatsByHallIdCommand request, CancellationToken cancellationToken)
    {
        return await seatsRepository.GetSeatsByHallIdAsync(request.HallId);
    }
}