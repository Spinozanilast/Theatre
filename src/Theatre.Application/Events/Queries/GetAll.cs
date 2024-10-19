using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Events.Queries;

public record GetAllEventsQuery() : IRequest<IList<Event>>;

public class GetAllQueryHandler(IEventsRepository eventsRepository) : IRequestHandler<GetAllEventsQuery, IList<Event>>
{
    private readonly IEventsRepository _eventsRepository = eventsRepository;

    public async Task<IList<Event>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
    {
        return await _eventsRepository.GetAllAsync();
    }
}