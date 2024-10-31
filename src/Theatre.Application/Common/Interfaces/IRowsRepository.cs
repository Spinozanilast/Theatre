using Theatre.Domain.Entities;

namespace Theatre.Application.Common.Interfaces;

public interface IRowsRepository
{
    Task<List<Row>> GetRowsByHallIdAsync(int hallId);
    Task<List<Row>> GetRowsBySectorIdAsync(int sectorId);
    Task<Row?> GetByIdAsync(int id);
    Task CreateAsync(Row rowEntity);
    Task UpdateAsync(Row rawEntity);
    Task DeleteAsync(int id);
}