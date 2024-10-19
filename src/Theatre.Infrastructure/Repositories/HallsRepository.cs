using Microsoft.EntityFrameworkCore;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;
using Theatre.Infrastructure.Data;

namespace Theatre.Infrastructure.Repositories;

public class HallsRepository(TheatreDbContext theatreDbContext): IHallsRepository
{
    private readonly TheatreDbContext _theatreDbContext = theatreDbContext;
    public async Task<Hall?> GetByIdAsync(short id)
    {
        return await _theatreDbContext.Halls.FindAsync(id);
    }

    public async Task<List<Hall>> GetAllAsync()
    {
        return await _theatreDbContext.Halls.ToListAsync();
    }

    public async Task CreateAsync(Hall hallEntity)
    {
        await _theatreDbContext.AddAsync(hallEntity);
        await _theatreDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Hall hallEntity)
    {
        _theatreDbContext.Update(hallEntity);
        await _theatreDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(short id)
    {
        var hall = await GetByIdAsync(id);
        if (hall is not null)
        {
            _theatreDbContext.Remove(hall);
            await _theatreDbContext.SaveChangesAsync();
        }
    }
}