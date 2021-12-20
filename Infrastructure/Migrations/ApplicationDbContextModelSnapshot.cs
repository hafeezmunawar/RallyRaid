﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entitties.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarRaceId")
                        .HasColumnType("int");

                    b.Property<int>("DistanceCoveredInMiles")
                        .HasColumnType("int");

                    b.Property<bool>("FinishedRace")
                        .HasColumnType("bit");

                    b.Property<double>("MelfunctionChance")
                        .HasColumnType("float");

                    b.Property<int>("MelfunctionsOccured")
                        .HasColumnType("int");

                    b.Property<int>("RacedHours")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarRaceId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Domain.Entitties.CarRace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TimeLimit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CarRaces");
                });

            modelBuilder.Entity("Domain.Entitties.Motorbike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DistanceCoveredInMiles")
                        .HasColumnType("int");

                    b.Property<int>("FinishedRace")
                        .HasColumnType("int");

                    b.Property<double>("MelfunctionChance")
                        .HasColumnType("float");

                    b.Property<int>("MelfunctionsOccured")
                        .HasColumnType("int");

                    b.Property<int?>("MotorbikeRaceId")
                        .HasColumnType("int");

                    b.Property<int>("RacedHours")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MotorbikeRaceId");

                    b.ToTable("Motorbikes");
                });

            modelBuilder.Entity("Domain.Entitties.MotorbikeRace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TimeLimit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MotorbikeRaces");
                });

            modelBuilder.Entity("Domain.Entitties.Car", b =>
                {
                    b.HasOne("Domain.Entitties.CarRace", null)
                        .WithMany("Cars")
                        .HasForeignKey("CarRaceId");
                });

            modelBuilder.Entity("Domain.Entitties.Motorbike", b =>
                {
                    b.HasOne("Domain.Entitties.MotorbikeRace", null)
                        .WithMany("Motorbikes")
                        .HasForeignKey("MotorbikeRaceId");
                });

            modelBuilder.Entity("Domain.Entitties.CarRace", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Domain.Entitties.MotorbikeRace", b =>
                {
                    b.Navigation("Motorbikes");
                });
#pragma warning restore 612, 618
        }
    }
}
