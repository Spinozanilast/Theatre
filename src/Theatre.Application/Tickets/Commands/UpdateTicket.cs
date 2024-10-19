using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Tickets.Commands;

public record UpdateTicketCommand(Ticket TicketUpdated) : IRequest<ErrorOr<Success>>;

public class UpdateTicketCommandHandler(ITicketsRepository ticketsRepository)
    : IRequestHandler<UpdateTicketCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await ticketsRepository.GetByIdAsync(request.TicketUpdated.Id);
        if (ticket is null)
        {
            return Error.NotFound(description: "Ticket not found");
        }

        await ticketsRepository.UpdateAsync(request.TicketUpdated);
        return Result.Success;
    }
}