using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Events.Queries;

public record GetEventsByHallIdQuery(int HallId): IQuery<List<Event>>;

public class GetEventsByHallQueryHandler(IEventsRepository eventsRepository): IQueryHandler<GetEventsByHallIdQuery, List<Event>>
{
    public async ValueTask<List<Event>> Handle(GetEventsByHallIdQuery request, CancellationToken cancellationToken)
    {
        return await eventsRepository.GetEventsByHallAsync(request.HallId);
    }
}