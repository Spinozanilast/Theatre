using ErrorOr;
using Mediator;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Tickets.Commands;

public record UpdateTicketCommand(
    Guid TicketId,
    Guid EventId,
    Guid UserId,
    DateTime EndsAt,
    int HallId,
    decimal Price
): ICommand<ErrorOr<Success>>;

public class UpdateTicketCommandHandler(ITicketsRepository ticketsRepository)
    : ICommandHandler<UpdateTicketCommand, ErrorOr<Success>>
{
    public async ValueTask<ErrorOr<Success>> Handle(UpdateTicketCommand request, CancellationToken cn = default)
    {
        var ticket = await ticketsRepository.GetByIdAsync(request.TicketId);
        
        if (ticket is null)
        {
            return Error.NotFound(description: "Ticket not found");
        }

        ticket.Update(request.EventId, request.UserId, request.EndsAt, request.HallId, request.Price);

        await ticketsRepository.UpdateAsync(ticket);
        return Result.Success;
    }
}