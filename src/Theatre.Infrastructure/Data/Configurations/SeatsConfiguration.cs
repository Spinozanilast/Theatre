using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Theatre.Domain.Entities;

namespace Theatre.Infrastructure.Data.Configurations;

public class SeatsConfiguration : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.Property(s => s.SeatNumber)
            .IsRequired();
        
        builder.Property(s => s.IsOccupied)
            .HasDefaultValue(false);

        builder
            .HasOne(s => s.SeatTypeMultiplier)
            .WithMany();
    }
}