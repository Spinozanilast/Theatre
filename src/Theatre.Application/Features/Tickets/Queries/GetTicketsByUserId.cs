using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Queries;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Tickets.Queries;

public record GetTicketsByUserIdQuery(Guid UserId);

public class GetTicketsByUserIdQueryHandlerWithCancellation(ITicketsRepository ticketsRepository)
    : IQueryHandlerWithCancellation<GetTicketsByUserIdQuery, IList<Ticket>>
{
    public async Task<IList<Ticket>> Handle(GetTicketsByUserIdQuery request, CancellationToken cancellationToken)
    {
        return await ticketsRepository.GetTicketsByUserIdAsync(request.UserId);
    }
}