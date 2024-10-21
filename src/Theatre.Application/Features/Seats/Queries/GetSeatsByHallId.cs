using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Seats.Queries;

public record GetSeatsByHallIdCommand(short HallId) : IReturnType<IList<Seat>>;

public class GetSeatsByHallIdCommandHandler(ISeatsRepository seatsRepository)
    : ICommandHandler<GetSeatsByHallIdCommand, IList<Seat>>
{
    public async Task<IList<Seat>> Handle(GetSeatsByHallIdCommand request)
    {
        return await seatsRepository.GetSeatsByHallIdAsync(request.HallId);
    }
}