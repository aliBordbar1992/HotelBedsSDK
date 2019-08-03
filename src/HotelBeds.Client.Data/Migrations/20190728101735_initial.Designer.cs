﻿// <auto-generated />
using System;
using HotelBeds.Client.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelBeds.Client.Data.Migrations
{
    [DbContext(typeof(HotelbedsContext))]
    [Migration("20190728101735_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelBeds.Client.Data.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientReference");

                    b.Property<DateTime>("CreationDate");

                    b.Property<int>("HolderId");

                    b.Property<string>("Reference");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("HolderId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("HotelBeds.Client.Data.Models.BookingHolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Holders");
                });

            modelBuilder.Entity("HotelBeds.Client.Data.Models.Booking", b =>
                {
                    b.HasOne("HotelBeds.Client.Data.Models.BookingHolder", "Holder")
                        .WithMany("Bookings")
                        .HasForeignKey("HolderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
