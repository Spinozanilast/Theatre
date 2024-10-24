using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Theatre.Domain.Entities;

namespace Theatre.Infrastructure.Data.Configurations;

public class UsersConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasIndex(u => u.Email)
            .IsUnique()
            .HasDatabaseName("Unique_Email");

        builder
            .HasIndex(u => u.PhoneNumber)
            .IsUnique()
            .HasDatabaseName("Unique_PhoneNumber");
    }
}