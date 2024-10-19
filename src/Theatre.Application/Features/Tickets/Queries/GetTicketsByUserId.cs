using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Tickets.Queries;

public record GetTicketsByUserIdQuery(Guid UserId) : IRequest<IList<Ticket>>;

public class GetTicketsByUserIdQueryHandler(ITicketsRepository ticketsRepository)
    : IRequestHandler<GetTicketsByUserIdQuery, IList<Ticket>>
{
    public async Task<IList<Ticket>> Handle(GetTicketsByUserIdQuery request, CancellationToken cancellationToken)
    {
        return await ticketsRepository.GetTicketsByUserIdAsync(request.UserId);
    }
}