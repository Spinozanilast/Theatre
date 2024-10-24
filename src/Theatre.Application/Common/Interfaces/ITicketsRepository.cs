using Theatre.Domain.Entities;

namespace Theatre.Application.Common.Interfaces;

public interface ITicketsRepository
{
    Task<List<Ticket>> GetTicketsByUserIdAsync(Guid userId);
    Task<Ticket?> GetByIdAsync(Guid id);
    Task CreateAsync(Ticket ticketEntity);
    Task UpdateAsync(Ticket ticketEntity);
    Task DeleteAsync(Guid id);
}