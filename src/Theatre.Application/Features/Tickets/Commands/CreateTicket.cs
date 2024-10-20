using ErrorOr;
using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Tickets.Commands;

public record CreateTicketCommand(Ticket Ticket);

public class CreateTicketCommandHandler(ITicketsRepository ticketsRepository)
    : ICommandHandler<CreateTicketCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        await ticketsRepository.CreateAsync(request.Ticket);
        return Result.Success;
    }
}