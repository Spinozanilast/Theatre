using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Theatre.Domain.Entities;

namespace Theatre.Infrastructure.Data.Configurations;

public class TicketsConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder
            .HasIndex(t => new { t.EventId, t.UserId, t.HallId, t.SectorId, t.RowNumber, t.SeatNumber })
            .IsUnique()
            .HasDatabaseName("Unique_Ticket");

        builder
            .ConfigureOneToOneRelationship<Ticket, Event>(
                nameof(Event),
                s => s.EventId);

        builder
            .ConfigureOneToOneRelationship<Ticket, User>(
                nameof(User),
                s => s.UserId);

        builder
            .ConfigureOneToOneRelationship<Ticket, Hall>(
                nameof(Hall),
                s => s.HallId);

        builder
            .ConfigureOneToOneRelationship<Ticket, Sector>(
                nameof(Sector),
                s => s.SectorId);
    }
}