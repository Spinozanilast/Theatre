using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Theatre.Domain.Entities;

namespace Theatre.Infrastructure.Data.Configurations;

public class HallsConfiguration : IEntityTypeConfiguration<Hall>
{
    public void Configure(EntityTypeBuilder<Hall> builder)
    {
        builder
            .HasIndex(h => h.HallName)
            .IsUnique()
            .HasDatabaseName("Unique_HallName");

        builder
            .Property(h => h.SchemeGridRowsCount)
            .IsRequired();
        
        
        builder
            .Property(h => h.SchemeGridColumnsCount)
            .IsRequired();
    }
}