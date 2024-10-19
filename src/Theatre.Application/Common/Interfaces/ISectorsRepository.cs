using Theatre.Domain.Entities;

namespace Theatre.Application.Common.Interfaces;

public interface ISectorsRepository
{
    Task<IList<Sector>> GetSectorsByHallId(short hallId);
    Task<Sector?> GetByIdAsync(short id);
    Task CreateAsync(Sector sectorEntity);
    Task UpdateAsync(Sector sectorEntity);
    Task DeleteAsync(short id);
}