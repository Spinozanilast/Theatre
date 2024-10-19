using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Tickets.Commands;

public record DeleteTicketCommand(Guid TicketId) : IRequest<ErrorOr<Success>>;

public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, ErrorOr<Success>>
{
    private readonly ITicketsRepository _ticketsRepository;

    public DeleteTicketCommandHandler(ITicketsRepository ticketsRepository)
    {
        _ticketsRepository = ticketsRepository;
    }

    public async Task<ErrorOr<Success>> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        await _ticketsRepository.DeleteAsync(request.TicketId);
        return Result.Success;
    }
}