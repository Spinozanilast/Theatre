using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Seats.Queries;

public record GetSeatsByHallIdCommand(short HallId) : IRequest<IList<Seat>>;

public class GetSeatsByHallIdCommandHandler : IRequestHandler<GetSeatsByHallIdCommand, IList<Seat>>
{
    private readonly ISeatsRepository _seatsRepository;

    public GetSeatsByHallIdCommandHandler(ISeatsRepository seatsRepository)
    {
        _seatsRepository = seatsRepository;
    }

    public async Task<IList<Seat>> Handle(GetSeatsByHallIdCommand request, CancellationToken cancellationToken)
    {
        return await _seatsRepository.GetSeatsByHallIdAsync(request.HallId);
    }
}