using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Events.Queries;

public record GetEventsByHallQuery(short HallId) : IRequest<IList<Event>>;

public class GetEventsByHallQueryHandler : IRequestHandler<GetEventsByHallQuery, IList<Event>>
{
    private readonly IEventsRepository _eventsRepository;

    public GetEventsByHallQueryHandler(IEventsRepository eventsRepository)
    {
        _eventsRepository = eventsRepository;
    }

    public async Task<IList<Event>> Handle(GetEventsByHallQuery request, CancellationToken cancellationToken)
    {
        return await _eventsRepository.GetEventsByHallAsync(request.HallId);
    }
}