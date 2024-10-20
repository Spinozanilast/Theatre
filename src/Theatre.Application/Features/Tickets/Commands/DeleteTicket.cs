using ErrorOr;
using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Tickets.Commands;     

public record DeleteTicketCommand(Guid TicketId);

public class DeleteTicketCommandHandler(ITicketsRepository ticketsRepository)
    : ICommandHandler<DeleteTicketCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        await ticketsRepository.DeleteAsync(request.TicketId);
        return Result.Success;
    }
}