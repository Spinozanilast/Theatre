using ErrorOr;
using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;

namespace Theatre.Application.Features.Tickets.Commands;

public record DeleteTicketCommand(Guid TicketId) : IReturnType<ErrorOr<Success>>;

public class DeleteTicketCommandHandler(ITicketsRepository ticketsRepository)
    : ICommandHandlerWithCancellation<DeleteTicketCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        await ticketsRepository.DeleteAsync(request.TicketId);
        return Result.Success;
    }
}