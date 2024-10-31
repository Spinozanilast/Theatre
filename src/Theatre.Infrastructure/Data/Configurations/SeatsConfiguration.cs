using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Theatre.Domain.Common;
using Theatre.Domain.Entities;
using Theatre.Domain.Entities.Enumerations;

namespace Theatre.Infrastructure.Data.Configurations;

public class SeatsConfiguration : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder
            .HasIndex(s => new { s.HallId, s.SectorId, s.RowNumber, s.SeatNumber })
            .IsUnique()
            .HasDatabaseName("Unique_Seat");

        builder
            .Property(s => s.SeatType)
            .HasConversion(
                enumInstance => enumInstance.Name,
                name => Enumeration.EnumFromName<SeatType>(name));
        
        builder
            .HasIndex(s => new { s.HallId, s.RowNumber })
            .HasDatabaseName("IX_Seats_HallId_RowNumber");
    }
}