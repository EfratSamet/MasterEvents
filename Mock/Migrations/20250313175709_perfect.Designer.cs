﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mock;

#nullable disable

namespace Mock.Migrations
{
    [DbContext(typeof(MyDataBase))]
    [Migration("20250313175709_perfect")]
    partial class perfect
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Repository.Entity.Event", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("eventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("eventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("invitation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("organizerId")
                        .HasColumnType("int");

                    b.Property<bool>("seperation")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("organizerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Repository.Entity.Group", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("organizerId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("organizerId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Repository.Entity.Guest", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("Groupid")
                        .HasColumnType("int");

                    b.Property<int>("gender")
                        .HasColumnType("int");

                    b.Property<string>("mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Groupid");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("Repository.Entity.GuestInEvent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("eventId")
                        .HasColumnType("int");

                    b.Property<int>("groupId")
                        .HasColumnType("int");

                    b.Property<int>("guestId")
                        .HasColumnType("int");

                    b.Property<bool>("ok")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("eventId");

                    b.HasIndex("groupId");

                    b.HasIndex("guestId");

                    b.ToTable("GuestInEvents");
                });

            modelBuilder.Entity("Repository.Entity.Organizer", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("id"), 1L, 1);

                    b.Property<string>("mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("mail")
                        .IsUnique();

                    b.ToTable("Organizers");
                });

            modelBuilder.Entity("Repository.Entity.PhotosFromEvent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("blessing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("eventId")
                        .HasColumnType("int");

                    b.Property<int>("guestId")
                        .HasColumnType("int");

                    b.Property<string>("imageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("eventId");

                    b.HasIndex("guestId");

                    b.ToTable("PhotosFromEvents");
                });

            modelBuilder.Entity("Repository.Entity.Seating", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("eventId")
                        .HasColumnType("int");

                    b.Property<int>("seat")
                        .HasColumnType("int");

                    b.Property<int>("subGuestId")
                        .HasColumnType("int");

                    b.Property<int>("table")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("eventId");

                    b.HasIndex("subGuestId");

                    b.ToTable("Seatings");
                });

            modelBuilder.Entity("Repository.Entity.SubGuest", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("gender")
                        .HasColumnType("int");

                    b.Property<int>("guestId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("guestId");

                    b.ToTable("SubGuests");
                });

            modelBuilder.Entity("Repository.Entity.Event", b =>
                {
                    b.HasOne("Repository.Entity.Organizer", "organizer")
                        .WithMany("events")
                        .HasForeignKey("organizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("organizer");
                });

            modelBuilder.Entity("Repository.Entity.Group", b =>
                {
                    b.HasOne("Repository.Entity.Organizer", "organizer")
                        .WithMany("groups")
                        .HasForeignKey("organizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("organizer");
                });

            modelBuilder.Entity("Repository.Entity.Guest", b =>
                {
                    b.HasOne("Repository.Entity.Group", null)
                        .WithMany("guests")
                        .HasForeignKey("Groupid");
                });

            modelBuilder.Entity("Repository.Entity.GuestInEvent", b =>
                {
                    b.HasOne("Repository.Entity.Event", "event_")
                        .WithMany("guests")
                        .HasForeignKey("eventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Repository.Entity.Group", "group_")
                        .WithMany()
                        .HasForeignKey("groupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Repository.Entity.Guest", "guest")
                        .WithMany()
                        .HasForeignKey("guestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("event_");

                    b.Navigation("group_");

                    b.Navigation("guest");
                });

            modelBuilder.Entity("Repository.Entity.PhotosFromEvent", b =>
                {
                    b.HasOne("Repository.Entity.Event", "event_")
                        .WithMany("photos")
                        .HasForeignKey("eventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repository.Entity.Guest", "guest")
                        .WithMany()
                        .HasForeignKey("guestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("event_");

                    b.Navigation("guest");
                });

            modelBuilder.Entity("Repository.Entity.Seating", b =>
                {
                    b.HasOne("Repository.Entity.Event", "event_")
                        .WithMany()
                        .HasForeignKey("eventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repository.Entity.SubGuest", "subGuest")
                        .WithMany()
                        .HasForeignKey("subGuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("event_");

                    b.Navigation("subGuest");
                });

            modelBuilder.Entity("Repository.Entity.SubGuest", b =>
                {
                    b.HasOne("Repository.Entity.Guest", "guest")
                        .WithMany()
                        .HasForeignKey("guestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("guest");
                });

            modelBuilder.Entity("Repository.Entity.Event", b =>
                {
                    b.Navigation("guests");

                    b.Navigation("photos");
                });

            modelBuilder.Entity("Repository.Entity.Group", b =>
                {
                    b.Navigation("guests");
                });

            modelBuilder.Entity("Repository.Entity.Organizer", b =>
                {
                    b.Navigation("events");

                    b.Navigation("groups");
                });
#pragma warning restore 612, 618
        }
    }
}
