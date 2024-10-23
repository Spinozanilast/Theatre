using ErrorOr;
using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;
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
    DateTime StartsAt
) : IReturnType<ErrorOr<Ticket>>;

public class CreateTicketCommandHandler(ITicketsRepository ticketsRepository)
    : ICommandHandler<CreateTicketCommand, ErrorOr<Ticket>>, IHandler
{
    public async Task<ErrorOr<Ticket>> Handle(CreateTicketCommand request)
    {
        var ticket = new Ticket(new Guid(), request.EventId, request.UserId, request.HallId, request.SectorId,
            request.RowNumber, request.SeatNumber, request.Price, request.EndsAt, request.StartsAt);
        await ticketsRepository.CreateAsync(ticket);
        return ticket;
    }
}