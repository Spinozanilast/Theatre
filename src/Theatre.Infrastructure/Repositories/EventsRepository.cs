using Microsoft.EntityFrameworkCore;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;
using Theatre.Infrastructure.Data;

namespace Theatre.Infrastructure.Repositories;

public class EventsRepository(TheatreDbContext dbContext) : IEventsRepository
{
    private readonly TheatreDbContext _dbContext = dbContext;

    public async Task<List<Event>> GetEventsByHallAsync(int hallId)
    {
        return await _dbContext
            .Events.Where(e => e.HallId == hallId).AsNoTracking().ToListAsync();
    }

    public async Task<Event?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Events.FindAsync(id);
    }


    public async Task<List<Event>> GetAllAsync()
    {
        return await _dbContext.Events.AsNoTracking().ToListAsync();
    }

    public async Task CreateAsync(Event eventEntity)
    {
        await _dbContext.AddAsync(eventEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Event eventEntity)
    {
        _dbContext.Update(eventEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await GetByIdAsync(id);
        if (user is not null)
        {
            _dbContext.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}