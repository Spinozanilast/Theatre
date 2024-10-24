using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Theatre.Domain.Common;
using Theatre.Domain.Entities;
using Theatre.Domain.Entities.Enumerations;
using Theatre.Domain.Entities.Special;

namespace Theatre.Infrastructure.Data.Configurations;

public class EventsConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder
            .Property(e => e.EventType)
            .HasConversion(subscriptionType => subscriptionType.Name,
                value => Enumeration.EnumFromName<EventType>(value));

        builder
            .ConfigureOneToOneRelationship<Event, Hall>(
                nameof(Hall),
                s => s.HallId);

        builder
            .OwnsOne<EventCast>(e => e.EventCast)
            .ToTable("EventCasts");
    }
}