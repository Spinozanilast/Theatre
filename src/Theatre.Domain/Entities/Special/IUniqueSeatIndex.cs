namespace Theatre.Domain.Entities;

public interface IUniqueSeatIndex<out T> where T : struct
{
    public T HallId { get; }
    public T SectorId { get; }
    public T RowNumber { get; }
    public T SeatNumber { get; }
}