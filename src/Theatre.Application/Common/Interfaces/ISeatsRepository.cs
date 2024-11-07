using Theatre.Domain.Containers;
using Theatre.Domain.Entities;

namespace Theatre.Application.Common.Interfaces;

public interface ISeatsRepository
{
    Task<List<SectorWithRows>> GetSeatsByHallIdAsync(int hallId);
    Task<List<Seat>> GetSeatsBySectorIdAsync(int sectorId);
    Task<Seat?> GetByIdAsync(int id);
    Task CreateAsync(Seat seatEntity);
    Task UpdateAsync(Seat seatEntity);
    Task DeleteAsync(int id);
}