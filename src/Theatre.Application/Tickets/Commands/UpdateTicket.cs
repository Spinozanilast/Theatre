using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Tickets.Commands;

public record UpdateTicketCommand(Ticket TicketUpdated) : IRequest<ErrorOr<Success>>;

public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, ErrorOr<Success>>
{
    private readonly ITicketsRepository _ticketsRepository;

    public UpdateTicketCommandHandler(ITicketsRepository ticketsRepository)
    {
        _ticketsRepository = ticketsRepository;
    }

    public async Task<ErrorOr<Success>> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketsRepository.GetByIdAsync(request.TicketUpdated.Id);
        if (ticket is null)
        {
            return Error.NotFound(description: "Ticket not found");
        }

        await _ticketsRepository.UpdateAsync(request.TicketUpdated);
        return Result.Success;
    }
}