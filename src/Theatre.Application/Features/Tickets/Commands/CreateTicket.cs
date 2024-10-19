using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Tickets.Commands;

public record CreateTicketCommand(Ticket Ticket) : IRequest<ErrorOr<Success>>;

public class CreateTicketCommandHandler(ITicketsRepository ticketsRepository)
    : IRequestHandler<CreateTicketCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        await ticketsRepository.CreateAsync(request.Ticket);
        return Result.Success;
    }
}