using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Events.Queries;

public record GetAllEventsQuery: IQuery<List<Event>>;

public class GetAllEventsQueryHandler(IEventsRepository eventsRepository): IQueryHandler<GetAllEventsQuery, List<Event>>
{
    public async ValueTask<List<Event>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
    {
        return await eventsRepository.GetAllAsync();
    }
}