using Theatre.Domain.Entities;

namespace Theatre.Application.Common.Interfaces;

public interface IEventsRepository
{
    Task<List<Event>> GetEventsByHallAsync(short hallId);
    Task<List<Event>> GetAllAsync();
    Task<Event?> GetByIdAsync(Guid id);
    Task CreateAsync(Event eventEntity);
    Task UpdateAsync(Event eventEntity);
    Task DeleteAsync(Guid id);
}