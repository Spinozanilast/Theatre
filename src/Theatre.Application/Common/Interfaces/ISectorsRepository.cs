using Theatre.Domain.Entities;

namespace Theatre.Application.Common.Interfaces;

public interface ISectorsRepository
{
    Task<List<Sector>> GetSectorsByHallId(int hallId);
    Task<Sector?> GetByIdAsync(int id);
    Task CreateAsync(Sector sectorEntity);
    Task UpdateAsync(Sector sectorEntity);
    Task DeleteAsync(int id);
}