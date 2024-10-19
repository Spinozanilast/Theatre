using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Tickets.Commands;

public record CreateTicketCommand(Ticket Ticket) : IRequest<ErrorOr<Success>>;

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, ErrorOr<Success>>
{
    private readonly ITicketsRepository _ticketsRepository;

    public CreateTicketCommandHandler(ITicketsRepository ticketsRepository)
    {
        _ticketsRepository = ticketsRepository;
    }

    public async Task<ErrorOr<Success>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        await _ticketsRepository.CreateAsync(request.Ticket);
        return Result.Success;
    }
}