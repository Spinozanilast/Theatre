using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Tickets.Commands;

public record DeleteTicketCommand(Guid TicketId) : IRequest<ErrorOr<Success>>;

public class DeleteTicketCommandHandler(ITicketsRepository ticketsRepository)
    : IRequestHandler<DeleteTicketCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        await ticketsRepository.DeleteAsync(request.TicketId);
        return Result.Success;
    }
}