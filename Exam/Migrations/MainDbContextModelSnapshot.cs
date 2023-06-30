﻿// <auto-generated />
using System;
using Exam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Exam.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Exam.Models.Artist", b =>
                {
                    b.Property<int>("IdArtist")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArtist"));

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdArtist");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            IdArtist = 1,
                            Nickname = "art1"
                        },
                        new
                        {
                            IdArtist = 2,
                            Nickname = "art2"
                        });
                });

            modelBuilder.Entity("Exam.Models.Artist_Event", b =>
                {
                    b.Property<int>("IdArtist")
                        .HasColumnType("int");

                    b.Property<int>("IdEvent")
                        .HasColumnType("int");

                    b.Property<DateTime>("PerformanceDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdArtist", "IdEvent")
                        .HasName("Artist_Event_pk");

                    b.HasIndex("IdEvent");

                    b.ToTable("ArtistEvents");

                    b.HasData(
                        new
                        {
                            IdArtist = 2,
                            IdEvent = 1,
                            PerformanceDate = new DateTime(2023, 6, 30, 15, 9, 42, 2, DateTimeKind.Local).AddTicks(9486)
                        },
                        new
                        {
                            IdArtist = 2,
                            IdEvent = 2,
                            PerformanceDate = new DateTime(2023, 7, 1, 15, 9, 42, 2, DateTimeKind.Local).AddTicks(9548)
                        });
                });

            modelBuilder.Entity("Exam.Models.Event", b =>
                {
                    b.Property<int>("IdEvent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEvent"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdEvent");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            IdEvent = 1,
                            EndDate = new DateTime(2023, 6, 30, 18, 9, 42, 1, DateTimeKind.Local).AddTicks(5401),
                            Name = "Test event 1",
                            StartDate = new DateTime(2023, 6, 30, 10, 9, 42, 1, DateTimeKind.Local).AddTicks(5331)
                        },
                        new
                        {
                            IdEvent = 2,
                            EndDate = new DateTime(2023, 7, 1, 18, 9, 42, 1, DateTimeKind.Local).AddTicks(5413),
                            Name = "Test event 2",
                            StartDate = new DateTime(2023, 7, 1, 10, 9, 42, 1, DateTimeKind.Local).AddTicks(5409)
                        });
                });

            modelBuilder.Entity("Exam.Models.Event_Organiser", b =>
                {
                    b.Property<int>("IdEvent")
                        .HasColumnType("int");

                    b.Property<int>("IdOrganiser")
                        .HasColumnType("int");

                    b.HasKey("IdEvent", "IdOrganiser")
                        .HasName("Event_Organiser`_pk");

                    b.HasIndex("IdOrganiser");

                    b.ToTable("EventsOrganisers");

                    b.HasData(
                        new
                        {
                            IdEvent = 1,
                            IdOrganiser = 1
                        },
                        new
                        {
                            IdEvent = 2,
                            IdOrganiser = 2
                        });
                });

            modelBuilder.Entity("Exam.Models.Organiser", b =>
                {
                    b.Property<int>("IdOrganiser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOrganiser"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdOrganiser");

                    b.ToTable("Organisers");

                    b.HasData(
                        new
                        {
                            IdOrganiser = 1,
                            Name = "Organizer 1"
                        },
                        new
                        {
                            IdOrganiser = 2,
                            Name = "Organizer 2"
                        });
                });

            modelBuilder.Entity("Exam.Models.Artist_Event", b =>
                {
                    b.HasOne("Exam.Models.Artist", "Artist")
                        .WithMany("ArtistEvents")
                        .HasForeignKey("IdArtist")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Exam.Models.Event", "Event")
                        .WithMany("ArtistEvents")
                        .HasForeignKey("IdEvent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Exam.Models.Event_Organiser", b =>
                {
                    b.HasOne("Exam.Models.Event", "Event")
                        .WithMany("EventOrganisers")
                        .HasForeignKey("IdEvent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Exam.Models.Organiser", "Organiser")
                        .WithMany("EventOrganisers")
                        .HasForeignKey("IdOrganiser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Organiser");
                });

            modelBuilder.Entity("Exam.Models.Artist", b =>
                {
                    b.Navigation("ArtistEvents");
                });

            modelBuilder.Entity("Exam.Models.Event", b =>
                {
                    b.Navigation("ArtistEvents");

                    b.Navigation("EventOrganisers");
                });

            modelBuilder.Entity("Exam.Models.Organiser", b =>
                {
                    b.Navigation("EventOrganisers");
                });
#pragma warning restore 612, 618
        }
    }
}
