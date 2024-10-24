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
            .ConfigureOneToOneRelationship<Seat, Hall>(
                nameof(Hall),
                s => s.HallId);

        builder
            .ConfigureOneToOneRelationship<Seat, Sector>(
                nameof(Sector),
                s => s.SectorId);

        builder
            .Property(s => s.SeatType)
            .HasConversion(
                enumInstance => enumInstance.Name,
                name => Enumeration.EnumFromName<SeatType>(name));
    }
}