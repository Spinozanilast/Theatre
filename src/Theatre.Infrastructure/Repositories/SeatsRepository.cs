using Microsoft.EntityFrameworkCore;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Containers;
using Theatre.Domain.Entities;
using Theatre.Domain.Entities.Special;
using Theatre.Infrastructure.Data;

namespace Theatre.Infrastructure.Repositories;

public class SeatsRepository(TheatreDbContext dbContext) : ISeatsRepository
{
    private readonly TheatreDbContext _dbContext = dbContext;

    public async Task<Seat?> GetByIdAsync(int id)
    {
        return await _dbContext.Seats.FindAsync(id);
    }

    public async Task<List<SectorWithRows>> GetSeatsByHallIdAsync(int hallId)
    {
        return await _dbContext.Sectors
            .Include(s => s.Rows)
            .ThenInclude(r => r.Seats)
            .Where(s => s.HallId == hallId)
            .Select(s => new SectorWithRows 
                {
                    SectorId = s.Id,
                    Rows = s.Rows.Select(r => new RowWithSeats
                    {
                        RowId = r.Id,
                        Seats = r.Seats.Select(seat => new SeatInfo
                        {
                            SeatId = seat.Id,
                            SeatNumber = seat.SeatNumber,
                            IsOccupied = seat.IsOccupied,
                            SeatTypeMultiplier = seat.SeatTypeMultiplier
                        }).ToList()
                    }).ToList()
                })
            .ToListAsync();
    }

    public async Task<List<Seat>> GetSeatsBySectorIdAsync(int sectorId)
    {
        return await _dbContext.Seats.Where(s => s.Row.SectorId == sectorId).ToListAsync();
    }

    public async Task CreateAsync(Seat seatEntity)
    {
        await _dbContext.AddAsync(seatEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Seat seatEntity)
    {
        _dbContext.Update(seatEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var seat = await GetByIdAsync(id);
        if (seat is not null)
        {
            _dbContext.Remove(seat);
            await _dbContext.SaveChangesAsync();
        }
    }
}