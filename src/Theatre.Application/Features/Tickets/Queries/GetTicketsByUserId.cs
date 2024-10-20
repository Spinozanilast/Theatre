using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Tickets.Queries;

public record GetTicketsByUserIdQuery(Guid UserId);

public class GetTicketsByUserIdQueryHandler(ITicketsRepository ticketsRepository)
    : IQueryHandler<GetTicketsByUserIdQuery, IList<Ticket>>
{
    public async Task<IList<Ticket>> Handle(GetTicketsByUserIdQuery request, CancellationToken cancellationToken)
    {
        return await ticketsRepository.GetTicketsByUserIdAsync(request.UserId);
    }
}