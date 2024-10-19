using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Tickets.Queries;

public record GetTicketsByUserIdQuery(Guid UserId) : IRequest<IList<Ticket>>;

public class GetTicketsByUserIdQueryHandler : IRequestHandler<GetTicketsByUserIdQuery, IList<Ticket>>
{
    private readonly ITicketsRepository _ticketsRepository;

    public GetTicketsByUserIdQueryHandler(ITicketsRepository ticketsRepository)
    {
        _ticketsRepository = ticketsRepository;
    }

    public async Task<IList<Ticket>> Handle(GetTicketsByUserIdQuery request, CancellationToken cancellationToken)
    {
        return await _ticketsRepository.GetTicketsByUserIdAsync(request.UserId);
    }
}