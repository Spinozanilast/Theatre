using Microsoft.EntityFrameworkCore;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;
using Theatre.Infrastructure.Data;

namespace Theatre.Infrastructure.Repositories;

public class TicketsRepository(TheatreDbContext dbContext) : ITicketsRepository
{
    private readonly TheatreDbContext _dbContext = dbContext;

    public async Task<List<Ticket>> GetTicketsByUserIdAsync(Guid userId)
    {
        return await _dbContext.Tickets.AsNoTracking().Where(ticket => ticket.UserId == userId).ToListAsync();
    }

    public async Task<Ticket?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Tickets.FindAsync(id);
    }

    public async Task CreateAsync(Ticket ticketEntity)
    {
        await _dbContext.AddAsync(ticketEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Ticket ticketEntity)
    {
        _dbContext.Update(ticketEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var ticket = await GetByIdAsync(id);
        if (ticket is not null)
        {
            _dbContext.Remove(ticket);
            await _dbContext.SaveChangesAsync();
        }
    }
}