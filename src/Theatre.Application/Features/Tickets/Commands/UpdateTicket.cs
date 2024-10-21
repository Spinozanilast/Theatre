using ErrorOr;
using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;

namespace Theatre.Application.Features.Tickets.Commands;

public record UpdateTicketCommand(
    Guid TicketId,
    Guid EventId,
    Guid UserId,
    DateTime EndsAt,
    short HallId,
    short SectorId,
    short RowNumber,
    short SeatNumber,
    decimal Price
) : IReturnType<ErrorOr<Success>>;

public class UpdateTicketCommandHandler(ITicketsRepository ticketsRepository)
    : ICommandHandlerWithCancellation<UpdateTicketCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await ticketsRepository.GetByIdAsync(request.TicketId);
        if (ticket is null)
        {
            return Error.NotFound(description: "Ticket not found");
        }

        ticket.Update(request.EventId, request.UserId, request.EndsAt, request.HallId, request.SectorId,
            request.RowNumber, request.SeatNumber, request.Price);

        await ticketsRepository.UpdateAsync(ticket);
        return Result.Success;
    }
}