using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Events.Queries;

public record GetEventsByHallQuery(short HallId) : IRequest<IList<Event>>;

public class GetEventsByHallQueryHandler(IEventsRepository eventsRepository)
    : IRequestHandler<GetEventsByHallQuery, IList<Event>>
{
    public async Task<IList<Event>> Handle(GetEventsByHallQuery request, CancellationToken cancellationToken)
    {
        return await eventsRepository.GetEventsByHallAsync(request.HallId);
    }
}