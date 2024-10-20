using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;


public record GetEventsByHallQuery(short HallId);

public class GetEventsByHallQueryHandler(IEventsRepository eventsRepository)
    : ICommandHandler<GetEventsByHallQuery, IList<Event>>
{
    public async Task<IList<Event>> Handle(GetEventsByHallQuery request, CancellationToken cancellationToken)
    {
        return await eventsRepository.GetEventsByHallAsync(request.HallId);
    }
}