using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Tickets.Queries;

public record GetTicketsByUserIdQuery(Guid UserId): IQuery<List<Ticket>>;

public class GetTicketsByUserIdQueryHandler(ITicketsRepository ticketsRepository): IQueryHandler<GetTicketsByUserIdQuery, List<Ticket>>
{
    public async ValueTask<List<Ticket>> Handle(GetTicketsByUserIdQuery request, CancellationToken cn = default)
    {
        return await ticketsRepository.GetTicketsByUserIdAsync(request.UserId);
    }
}