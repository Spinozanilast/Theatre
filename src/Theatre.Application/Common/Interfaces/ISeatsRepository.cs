using Theatre.Domain.Entities;

namespace Theatre.Application.Common.Interfaces;

public interface ISeatsRepository
{
    Task<IList<Seat>> GetSeatsByHallIdAsync(short hallId);
    Task<IList<Seat>> GetSeatsBySectorIdAsync(short sectorId);
    Task<Seat?> GetByIdAsync(int id);
    Task CreateAsync(Seat seatEntity);
    Task UpdateAsync(Seat seatEntity);
    Task DeleteAsync(int id);
}