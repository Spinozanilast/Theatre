﻿using Theatre.Domain.Entities;

namespace Theatre.Application.Common.Interfaces;

public interface ISeatsRepository
{
    Task<IList<Seat>> GetSeatsByHallIdAsync(int hallId);
    Task<IList<Seat>> GetSeatsBySectorIdAsync(int sectorId);
    Task<Seat?> GetByIdAsync(int id);
    Task CreateAsync(Seat seatEntity);
    Task UpdateAsync(Seat seatEntity);
    Task DeleteAsync(int id);
}