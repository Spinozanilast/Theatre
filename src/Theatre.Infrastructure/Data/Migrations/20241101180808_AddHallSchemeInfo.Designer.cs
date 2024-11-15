﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Theatre.Infrastructure.Data;

#nullable disable

namespace Theatre.Infrastructure.Data.Migrations
{
    [DbContext(typeof(TheatreDbContext))]
    [Migration("20241101180808_AddHallSchemeInfo")]
    partial class AddHallSchemeInfo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Theatre.Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("EventState")
                        .HasColumnType("boolean");

                    b.Property<string>("EventType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HallId")
                        .HasColumnType("integer");

                    b.Property<string[]>("ImageUrls")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("text[]");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Theatre.Domain.Entities.Hall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("HallName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SchemeGridColumnsCount")
                        .HasColumnType("integer");

                    b.Property<int>("SchemeGridRowsCount")
                        .HasColumnType("integer");

                    b.Property<int>("SeatsNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HallName")
                        .IsUnique()
                        .HasDatabaseName("Unique_HallName");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("Theatre.Domain.Entities.Row", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("HallId")
                        .HasColumnType("integer");

                    b.Property<int>("RowNumber")
                        .HasColumnType("integer");

                    b.Property<int>("SeatsNumber")
                        .HasColumnType("integer");

                    b.Property<int>("SectorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HallId");

                    b.HasIndex("SectorId");

                    b.ToTable("Rows");
                });

            modelBuilder.Entity("Theatre.Domain.Entities.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsOccupied")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<int>("RowId")
                        .HasColumnType("integer");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("integer");

                    b.Property<int>("SeatTypeMultiplierId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RowId");

                    b.HasIndex("SeatTypeMultiplierId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("Theatre.Domain.Entities.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("HallId")
                        .HasColumnType("integer");

                    b.Property<int>("RowsCount")
                        .HasColumnType("integer");

                    b.Property<int>("SeatsNum")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HallId");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("Theatre.Domain.Entities.Special.SeatTypeMultiplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Multiplier")
                        .HasColumnType("double precision");

                    b.Property<string>("SeatType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SeatType")
                        .IsUnique();

                    b.ToTable("SeatTypes");
                });

            modelBuilder.Entity("Theatre.Domain.Entities.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BookingTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndsAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uuid");

                    b.Property<int>("HallId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("RowNumber")
                        .HasColumnType("integer");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("integer");

                    b.Property<int>("SectorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartsAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.HasIndex("HallId")
                        .IsUnique();

                    b.HasIndex("SectorId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.HasIndex("EventId", "UserId", "HallId", "SectorId", "RowNumber", "SeatNumber")
                        .IsUnique()
                        .HasDatabaseName("Unique_Ticket");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Theatre.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VisitedEventsCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("Unique_Email");

                    b.HasIndex("PhoneNumber")
                        .IsUnique()
                        .HasDatabaseName("Unique_PhoneNumber");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Theatre.Domain.Entities.Event", b =>
                {
                    b.OwnsOne("Theatre.Domain.Entities.Special.EventCast", "EventCast", b1 =>
                        {
                            b1.Property<Guid>("EventId")
                                .HasColumnType("uuid");

                            b1.Property<string[]>("Actors")
                                .HasColumnType("text[]");

                            b1.Property<string[]>("Directors")
                                .HasColumnType("text[]");

                            b1.Property<string[]>("ScreenWriters")
                                .HasColumnType("text[]");

                            b1.HasKey("EventId");

                            b1.ToTable("EventCasts", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("EventId");
                        });

                    b.Navigation("EventCast")
                        .IsRequired();
                });

            modelBuilder.Entity("Theatre.Domain.Entities.Row", b =>
                {
                    b.HasOne("Theatre.Domain.Entities.Hall", "Hall")
                        .WithMany()
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Theatre.Domain.Entities.Sector", "Sector")
                        .WithMany("Rows")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hall");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("Theatre.Domain.Entities.Seat", b =>
                {
                    b.HasOne("Theatre.Domain.Entities.Row", "Row")
                        .WithMany("Seats")
                        .HasForeignKey("RowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Theatre.Domain.Entities.Special.SeatTypeMultiplier", "SeatTypeMultiplier")
                        .WithMany()
                        .HasForeignKey("SeatTypeMultiplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Row");

                    b.Navigation("SeatTypeMultiplier");
                });

            modelBuilder.Entity("Theatre.Domain.Entities.Sector", b =>
                {
                    b.HasOne("Theatre.Domain.Entities.Hall", "Hall")
                        .WithMany()
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hall");
                });

            modelBuilder.Entity("Theatre.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("Theatre.Domain.Entities.Event", "Event")
                        .WithOne()
                        .HasForeignKey("Theatre.Domain.Entities.Ticket", "EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Theatre.Domain.Entities.Hall", "Hall")
                        .WithOne()
                        .HasForeignKey("Theatre.Domain.Entities.Ticket", "HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Theatre.Domain.Entities.Sector", "Sector")
                        .WithOne()
                        .HasForeignKey("Theatre.Domain.Entities.Ticket", "SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Theatre.Domain.Entities.User", "User")
                        .WithOne()
                        .HasForeignKey("Theatre.Domain.Entities.Ticket", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Hall");

                    b.Navigation("Sector");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Theatre.Domain.Entities.Row", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("Theatre.Domain.Entities.Sector", b =>
                {
                    b.Navigation("Rows");
                });
#pragma warning restore 612, 618
        }
    }
}
