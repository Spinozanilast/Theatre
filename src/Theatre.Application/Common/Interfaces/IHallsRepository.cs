using Theatre.Domain.Entities;

namespace Theatre.Application.Common.Interfaces;

public interface IHallsRepository
{
    Task<Hall?> GetByIdAsync(int id);
    Task<IList<Hall>> GetAllAsync();
    Task CreateAsync(Hall hallEntity);
    Task UpdateAsync(Hall hallEntity);
    Task DeleteAsync(int id);
}