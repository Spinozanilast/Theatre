using Theatre.Domain.Entities;

namespace Theatre.Contracts.Tickets;

public static class TicketToContract
{
    public static TicketContract ToContract(this Ticket ticket)
    {
        return new TicketContract(ticket.EventId, ticket.UserId, ticket.HallId, ticket.SeatIds, ticket.Price, ticket.EndsAt, ticket.StartsAt, ticket.BookingTime);
    }
}