using ErrorOr;
using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Tickets.Commands;

public record CreateTicketCommand(
    Guid EventId,
    Guid UserId,
    int HallId,
    int SectorId,
    int RowNumber,
    int SeatNumber,
    decimal Price,
    DateTime EndsAt,
    DateTime StartsAt,
    DateTime BookingTime
): ICommand<ErrorOr<Ticket>>;

public class CreateTicketCommandHandler(ITicketsRepository ticketsRepository): ICommandHandler<CreateTicketCommand, ErrorOr<Ticket>>
{
    public async ValueTask<ErrorOr<Ticket>> Handle(CreateTicketCommand request, CancellationToken cn = default)
    {
        var ticket = new Ticket(new Guid(), request.EventId, request.UserId, request.HallId, request.SectorId,
            request.RowNumber, request.SeatNumber, request.Price, request.EndsAt, request.StartsAt, request.BookingTime);
        await ticketsRepository.CreateAsync(ticket);
        return ticket;
    }
}