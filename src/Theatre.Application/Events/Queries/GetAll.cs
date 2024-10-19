using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Events.Queries;

public record GetAllEventsQuery() : IRequest<IList<Event>>;

public class GetAllQueryHandler(IEventsRepository eventsRepository) : IRequestHandler<GetAllEventsQuery, IList<Event>>
{
    public async Task<IList<Event>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
    {
        return await eventsRepository.GetAllAsync();
    }
}