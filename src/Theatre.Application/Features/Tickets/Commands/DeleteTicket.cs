using ErrorOr;
using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;

namespace Theatre.Application.Features.Tickets.Commands;

public record DeleteTicketCommand(Guid TicketId) : IReturnType<ErrorOr<Success>>;

public class DeleteTicketCommandHandler(ITicketsRepository ticketsRepository)
    : ICommandHandler<DeleteTicketCommand, ErrorOr<Success>>, IHandler
{
    public async Task<ErrorOr<Success>> Handle(DeleteTicketCommand request)
    {
        await ticketsRepository.DeleteAsync(request.TicketId);
        return Result.Success;
    }
}