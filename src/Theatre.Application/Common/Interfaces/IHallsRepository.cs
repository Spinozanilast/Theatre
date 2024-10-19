using Theatre.Domain.Entities;

namespace Theatre.Application.Common.Interfaces;

public interface IHallsRepository
{
    Task<Hall?> GetByIdAsync(short id);
    Task<List<Hall>> GetAllAsync();
    Task CreateAsync(Hall hallEntity);
    Task UpdateAsync(Hall hallEntity);
    Task DeleteAsync(short id);
}