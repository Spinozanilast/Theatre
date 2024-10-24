using ErrorOr;
using Mediator;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Tickets.Commands;

public record DeleteTicketCommand(Guid TicketId): ICommand<ErrorOr<Success>>;

public class DeleteTicketCommandHandler(ITicketsRepository ticketsRepository): ICommandHandler<DeleteTicketCommand, ErrorOr<Success>>
{
    public async ValueTask<ErrorOr<Success>> Handle(DeleteTicketCommand request, CancellationToken cn = default)
    {
        await ticketsRepository.DeleteAsync(request.TicketId);
        return Result.Success;
    }
}