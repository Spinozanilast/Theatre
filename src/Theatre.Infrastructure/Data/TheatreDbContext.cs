using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Infrastructure.Data;

public class TheatreDbContext(DbContextOptions options) : DbContext(options), IUnitOfWork
{
    public DbSet<User> Users { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Sector> Sectors { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Hall> Halls { get; set; }
    public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureUsersSet(modelBuilder);
        ConfigureTicketsSet(modelBuilder);
        ConfigureSeatsSet(modelBuilder);
    }

    private static void ConfigureUsersSet(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique()
            .HasDatabaseName("Unique_Email");

        modelBuilder.Entity<User>()
            .HasIndex(u => u.PhoneNumber)
            .IsUnique()
            .HasDatabaseName("Unique_PhoneNumber");
    }
    
    private static void ConfigureHallsSet(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hall>()
            .HasIndex(h => h.HallName)
            .IsUnique()
            .HasDatabaseName("Unique_HallName");
    }

    private static void ConfigureTicketsSet(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>()
            .HasIndex(t => new { t.EventId, t.UserId, t.HallId, t.SectorId, t.RowNumber, t.SeatNumber })
            .IsUnique()
            .HasDatabaseName("Unique_Ticket");
    }

    private static void ConfigureSeatsSet(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Seat>()
            .HasIndex(s => new { s.HallId, s.SectorId, s.RowNumber, s.SeatNumber })
            .IsUnique()
            .HasDatabaseName("Unique_Seat");
    }

    public async Task CommitChangesAsync(CancellationToken cancellationToken = default)
    {
        await base.SaveChangesAsync(cancellationToken);
    }
}