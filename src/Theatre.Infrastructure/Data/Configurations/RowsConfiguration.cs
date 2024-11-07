using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Theatre.Domain.Entities;

namespace Theatre.Infrastructure.Data.Configurations;

public class RowsConfiguration: IEntityTypeConfiguration<Row>
{
    public void Configure(EntityTypeBuilder<Row> builder)
    {
        builder
            .HasOne(r => r.Sector)
            .WithMany(s => s.Rows)
            .HasForeignKey(r => r.SectorId);
    }
}