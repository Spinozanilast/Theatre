using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Queries;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Tickets.Queries;

public record GetTicketsByUserIdQuery(Guid UserId): IReturnType<IList<Ticket>>;

public class GetTicketsByUserIdQueryHandler(ITicketsRepository ticketsRepository)
    : IQueryHandler<GetTicketsByUserIdQuery, IList<Ticket>>, IHandler
{
    public async Task<IList<Ticket>> Handle(GetTicketsByUserIdQuery request)
    {
        return await ticketsRepository.GetTicketsByUserIdAsync(request.UserId);
    }
}