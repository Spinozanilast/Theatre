using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Theatre.Domain.Entities.Special;

namespace Theatre.Infrastructure.Data.Configurations;

public class SeatTypeMultipliersConfiguration : IEntityTypeConfiguration<SeatTypeMultiplier>
{
    public void Configure(EntityTypeBuilder<SeatTypeMultiplier> builder)
    {
        builder.HasKey(stm => stm.Id);
        
        builder.Property(stm => stm.SeatType).IsRequired();
        builder.HasIndex(stm => stm.SeatType).IsUnique();
    }
}