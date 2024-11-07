using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Theatre.Domain.Entities;

namespace Theatre.Infrastructure.Data.Configurations;

public class SectorConfiguration : IEntityTypeConfiguration<Sector>
{
    public void Configure(EntityTypeBuilder<Sector> builder)
    {
        builder.Property(s => s.RowsCount)
            .IsRequired();

        builder.Property(s => s.SeatsNum)
            .IsRequired();
    }
}