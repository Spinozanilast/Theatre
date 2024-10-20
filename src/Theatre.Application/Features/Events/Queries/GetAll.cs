using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Events.Queries;

public record GetAllEventsQuery();

public class GetAllQueryHandler(IEventsRepository eventsRepository) : ICommandHandler<GetAllEventsQuery, IList<Event>>
{
    public async Task<IList<Event>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
    {
        return await eventsRepository.GetAllAsync();
    }
}