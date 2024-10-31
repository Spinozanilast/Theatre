using Microsoft.EntityFrameworkCore;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;
using Theatre.Infrastructure.Data;

namespace Theatre.Infrastructure.Repositories;

public class SeatsRepository(TheatreDbContext theatreDbContext) : ISeatsRepository
{
    private readonly TheatreDbContext _theatreDbContext = theatreDbContext;

    public async Task<Seat?> GetByIdAsync(int id)
    {
        return await _theatreDbContext.Seats.FindAsync(id);
    }

    public async Task<List<Seat>> GetSeatsByHallIdAsync(int hallId)
    {
        return await _theatreDbContext.Seats.AsNoTracking().Where(seat => seat.HallId == hallId).OrderBy(s => hallId)
            .ThenBy(s => s.SectorId).ThenBy(s => s.RowNumber).ThenBy(s => s.SeatNumber).ToListAsync();
    }

    public async Task<List<Seat>> GetSeatsBySectorIdAsync(int sectorId)
    {
        return await _theatreDbContext.Seats.AsNoTracking().Where(seat => seat.SectorId == sectorId).ToListAsync();
    }

    public async Task CreateAsync(Seat seatEntity)
    {
        await _theatreDbContext.AddAsync(seatEntity);
        await _theatreDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Seat seatEntity)
    {
        _theatreDbContext.Update(seatEntity);
        await _theatreDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var seat = await GetByIdAsync(id);
        if (seat is not null)
        {
            _theatreDbContext.Remove(seat);
            await _theatreDbContext.SaveChangesAsync();
        }
    }
}