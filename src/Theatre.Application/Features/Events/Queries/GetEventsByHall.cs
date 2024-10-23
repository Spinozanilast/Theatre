using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Queries;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Events.Queries;

public record GetEventsByHallIdQuery(int HallId) : IReturnType<IList<Event>>;

public class GetEventsByHallQueryHandler(IEventsRepository eventsRepository)
    : IQueryHandlerWithCancellation<GetEventsByHallIdQuery, IList<Event>>, IHandler
{
    public async Task<IList<Event>> Handle(GetEventsByHallIdQuery request, CancellationToken cancellationToken)
    {
        return await eventsRepository.GetEventsByHallAsync(request.HallId);
    }
}