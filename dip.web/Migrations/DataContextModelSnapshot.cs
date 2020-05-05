﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dip.web.Data;

namespace dip.web.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dip.web.Data.Entities.DipEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Plaque")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.HasKey("Id");

                    b.ToTable("Dips");
                });

            modelBuilder.Entity("dip.web.Data.Entities.TripDetailEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<int?>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("TripDetails");
                });

            modelBuilder.Entity("dip.web.Data.Entities.TripEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DipId");

                    b.Property<DateTime?>("EndDate");

                    b.Property<float>("Qualification");

                    b.Property<string>("Remarks");

                    b.Property<string>("Source")
                        .HasMaxLength(500);

                    b.Property<double>("SourceLatitude");

                    b.Property<double>("SourceLongitude");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Target")
                        .HasMaxLength(500);

                    b.Property<double>("TargetLatitude");

                    b.Property<double>("TargetLongitude");

                    b.HasKey("Id");

                    b.HasIndex("DipId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("dip.web.Data.Entities.TripDetailEntity", b =>
                {
                    b.HasOne("dip.web.Data.Entities.TripEntity", "Trip")
                        .WithMany("TripDetails")
                        .HasForeignKey("TripId");
                });

            modelBuilder.Entity("dip.web.Data.Entities.TripEntity", b =>
                {
                    b.HasOne("dip.web.Data.Entities.DipEntity", "Dip")
                        .WithMany("Trips")
                        .HasForeignKey("DipId");
                });
#pragma warning restore 612, 618
        }
    }
}
