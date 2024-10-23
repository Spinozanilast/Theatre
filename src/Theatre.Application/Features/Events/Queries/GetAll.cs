using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Queries;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Events.Queries;

public record GetAllEventsQuery() : IReturnType<IList<Event>>;

public class GetAllQueryHandler(IEventsRepository eventsRepository)
    : IQueryHandlerWithCancellation<GetAllEventsQuery, IList<Event>>, IHandler
{
    public async Task<IList<Event>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
    {
        return await eventsRepository.GetAllAsync();
    }
}