using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Events.Queries;

public record GetEventsByHallQuery(short HallId) : IReturnType<IList<Event>>;

public class GetEventsByHallQueryHandler(IEventsRepository eventsRepository)
    : ICommandHandlerWithCancellation<GetEventsByHallQuery, IList<Event>>
{
    public async Task<IList<Event>> Handle(GetEventsByHallQuery request, CancellationToken cancellationToken)
    {
        return await eventsRepository.GetEventsByHallAsync(request.HallId);
    }
}