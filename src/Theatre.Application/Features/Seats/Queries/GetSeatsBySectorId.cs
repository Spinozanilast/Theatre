using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Seats.Queries;

public record GetSeatsBySectorIdCommand(short SectorId) : IReturnType<IList<Seat>>;

public class GetSeatsBySectorIdCommandHandler(ISeatsRepository seatsRepository)
    : ICommandHandler<GetSeatsBySectorIdCommand, IList<Seat>>
{
    public async Task<IList<Seat>> Handle(GetSeatsBySectorIdCommand request)
    {
        return await seatsRepository.GetSeatsBySectorIdAsync(request.SectorId);
    }
}