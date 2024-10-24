using Microsoft.EntityFrameworkCore;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;
using Theatre.Infrastructure.Data;

namespace Theatre.Infrastructure.Repositories;

public class SectorsRepository(TheatreDbContext dbContext) : ISectorsRepository
{
    private readonly TheatreDbContext _dbContext = dbContext;

    public async Task<Sector?> GetByIdAsync(int id)
    {
        return await _dbContext.Sectors.FindAsync(id);
    }

    public async Task<IList<Sector>> GetSectorsByHallId(int hallId)
    {
        return await _dbContext.Sectors.AsNoTracking().Where(sector => sector.HallId == hallId).ToListAsync();
    }

    public async Task CreateAsync(Sector sectorEntity)
    {
        await _dbContext.AddAsync(sectorEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Sector sectorEntity)
    {
        _dbContext.Update(sectorEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var sector = await GetByIdAsync(id);
        if (sector is not null)
        {
            _dbContext.Remove(sector);
            await _dbContext.SaveChangesAsync();
        }
    }
}