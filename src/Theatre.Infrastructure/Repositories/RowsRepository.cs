using Microsoft.EntityFrameworkCore;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;
using Theatre.Infrastructure.Data;

namespace Theatre.Infrastructure.Repositories;

public class RowsRepository(TheatreDbContext theatreDbContext) : IRowsRepository
{
    private readonly TheatreDbContext _theatreDbContext = theatreDbContext;

    public async Task<List<Row>> GetRowsByHallIdAsync(int hallId)
    {
        return await _theatreDbContext.Rows.Where(r => r.HallId == hallId).ToListAsync();
    }

    public async Task<List<Row>> GetRowsBySectorIdAsync(int sectorId)
    {
        return await _theatreDbContext.Rows.Where(r => r.SectorId == sectorId).ToListAsync();
    }

    public async Task<Row?> GetByIdAsync(int id)
    {
        return await _theatreDbContext.Rows.FindAsync(id);
    }

    public async Task CreateAsync(Row rowEntity)
    {
        await _theatreDbContext.AddAsync(rowEntity);
        await _theatreDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Row rawEntity)
    {
        _theatreDbContext.Update(rawEntity);
        await _theatreDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var row = await GetByIdAsync(id);
        if (row is not null)
        {
            _theatreDbContext.Remove(row);
            await _theatreDbContext.SaveChangesAsync();
        }
    }
}