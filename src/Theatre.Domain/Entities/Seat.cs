using Theatre.Domain.Common;
using Theatre.Domain.Entities.Special;

namespace Theatre.Domain.Entities;

    public class Seat : AutoIncrementedEntity<int>
    {
        public Seat(int rowId, int seatNumber, SeatTypeMultiplier seatTypeMultiplier, bool isOccupied = false)
        {
            RowId = rowId;
            SeatNumber = seatNumber;
            SeatTypeMultiplier = seatTypeMultiplier;
            IsOccupied = isOccupied;
        }

        private Seat() { }

        public int RowId { get; private set; }
        public Row Row { get; set; }
        public int SeatNumber { get; private set; }
        public SeatTypeMultiplier SeatTypeMultiplier { get; private set; }
        public bool IsOccupied { get; private set; }

        public void Update(int rowId, int seatNumber, SeatTypeMultiplier seatType)
        {
            RowId = rowId;
            SeatNumber = seatNumber;
            SeatTypeMultiplier = seatType;
        }

        public void Occupy()
        {
            IsOccupied = true;
        }
    }
