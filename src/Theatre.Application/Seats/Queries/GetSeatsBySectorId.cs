using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Seats.Queries;

public record GetSeatsBySectorIdCommand(short SectorId) : IRequest<IList<Seat>>;

public class GetSeatsBySectorIdCommandHandler : IRequestHandler<GetSeatsBySectorIdCommand, IList<Seat>>
{
    private readonly ISeatsRepository _seatsRepository;

    public GetSeatsBySectorIdCommandHandler(ISeatsRepository seatsRepository)
    {
        _seatsRepository = seatsRepository;
    }

    public async Task<IList<Seat>> Handle(GetSeatsBySectorIdCommand request, CancellationToken cancellationToken)
    {
        return await _seatsRepository.GetSeatsBySectorIdAsync(request.SectorId);
    }
}