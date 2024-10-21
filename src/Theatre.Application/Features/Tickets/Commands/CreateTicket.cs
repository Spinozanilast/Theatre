using ErrorOr;
using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Tickets.Commands;

public record CreateTicketCommand(Ticket Ticket): IReturnType<ErrorOr<Success>>;

public class CreateTicketCommandHandler(ITicketsRepository ticketsRepository)
    : ICommandHandlerWithCancellation<CreateTicketCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        await ticketsRepository.CreateAsync(request.Ticket);
        return Result.Success;
    }
}