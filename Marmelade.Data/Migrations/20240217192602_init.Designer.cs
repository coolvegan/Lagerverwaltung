﻿// <auto-generated />
using System;
using Marmelade.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Marmelade.Data.Migrations
{
    [DbContext(typeof(DatenbankContext))]
    [Migration("20240217192602_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Marmelade.Data.ApiEinstellung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthenticationSchluessel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApiEinstellungen");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthenticationSchluessel = "ChangeMe",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1280),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1320),
                            UpdatedBy = "Marco Kittel"
                        });
                });

            modelBuilder.Entity("Marmelade.Data.Benutzer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Benutzer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1490),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1490),
                            Name = "paul",
                            Password = "63b4f9e2e7cc082b0eb953d998b0d7137fb8970f8de2fa594e3338449f512511",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1760),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1760),
                            Name = "peter",
                            Password = "93d8057a6c851b1f0e0038fd660f6ed563c6f56067b8c8f05da6022218d79e3b",
                            UpdatedBy = "Marco Kittel"
                        });
                });

            modelBuilder.Entity("Marmelade.Data.Lagergegenstand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BenutzerId")
                        .HasColumnType("int");

                    b.Property<string>("Beschreibung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LagerortId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Lagerzeitpunkt")
                        .HasColumnType("datetime2");

                    b.Property<double>("Menge")
                        .HasColumnType("float");

                    b.Property<string>("Mengenbezeichner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BenutzerId");

                    b.HasIndex("LagerortId");

                    b.ToTable("Lagergegenstand");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BenutzerId = 2,
                            Beschreibung = "Frische Fruchtmarmelade",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1890),
                            CreatedBy = "Marco Kittel",
                            LagerortId = 1,
                            Lagerzeitpunkt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1890),
                            Menge = 500.0,
                            Mengenbezeichner = "Gramm",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1890),
                            Name = "Melonen Marmelade",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 2,
                            BenutzerId = 2,
                            Beschreibung = "Frische Fruchtmarmelade",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1900),
                            CreatedBy = "Marco Kittel",
                            LagerortId = 5,
                            Lagerzeitpunkt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1900),
                            Menge = 750.0,
                            Mengenbezeichner = "Gramm",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1900),
                            Name = "Erdbeer Marmelade",
                            UpdatedBy = "Marco Kittel"
                        });
                });

            modelBuilder.Entity("Marmelade.Data.Lagerort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BenutzerId")
                        .HasColumnType("int");

                    b.Property<string>("Beschreibung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BenutzerId");

                    b.HasIndex("Name", "BenutzerId")
                        .IsUnique();

                    b.ToTable("Lagerorte");

                    b.HasData(
                        new
                        {
                            Id = 13,
                            BenutzerId = 2,
                            Beschreibung = "Kühlschrank C",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1970),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1970),
                            Name = "C1",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 14,
                            BenutzerId = 2,
                            Beschreibung = "Kühlschrank C",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1970),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1970),
                            Name = "C2",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 15,
                            BenutzerId = 2,
                            Beschreibung = "Kühlschrank C",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1970),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1970),
                            Name = "C3",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 16,
                            BenutzerId = 2,
                            Beschreibung = "Kühlschrank C",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1980),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1980),
                            Name = "C4",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 17,
                            BenutzerId = 2,
                            Beschreibung = "Kühlschrank C",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1980),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1980),
                            Name = "C5",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 1,
                            BenutzerId = 2,
                            Beschreibung = "Kühlschrank A",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1910),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1910),
                            Name = "A1",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 2,
                            BenutzerId = 2,
                            Beschreibung = "Kühlschrank A",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1930),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1930),
                            Name = "A2",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 3,
                            BenutzerId = 2,
                            Beschreibung = "Kühlschrank A",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1930),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1930),
                            Name = "A3",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 4,
                            BenutzerId = 2,
                            Beschreibung = "Kühlschrank A",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1930),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1930),
                            Name = "A4",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 5,
                            BenutzerId = 2,
                            Beschreibung = "Kühlschrank A",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1940),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1940),
                            Name = "A5",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 6,
                            BenutzerId = 2,
                            Beschreibung = "Kühlschrank A",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1940),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1940),
                            Name = "A6",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 7,
                            BenutzerId = 2,
                            Beschreibung = "Kühlschrank B",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1950),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1950),
                            Name = "B1",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 8,
                            BenutzerId = 2,
                            Beschreibung = "Kühlschrank B",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1950),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1950),
                            Name = "B2",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 9,
                            BenutzerId = 2,
                            Beschreibung = "Kühlschrank B",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1950),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1950),
                            Name = "B3",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 10,
                            BenutzerId = 2,
                            Beschreibung = "Kühlschrank B",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1960),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1960),
                            Name = "B4",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 11,
                            BenutzerId = 2,
                            Beschreibung = "Kühlschrank B",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1960),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1960),
                            Name = "B5",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 12,
                            BenutzerId = 2,
                            Beschreibung = "Kühlschrank B",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1960),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1960),
                            Name = "B6",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 18,
                            BenutzerId = 2,
                            Beschreibung = "Kühlschrank G",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1990),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1990),
                            Name = "G1",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 19,
                            BenutzerId = 2,
                            Beschreibung = "Kühlschrank G",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(2000),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(2000),
                            Name = "G2",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 20,
                            BenutzerId = 2,
                            Beschreibung = "Garage",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(2000),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(2000),
                            Name = "GA",
                            UpdatedBy = "Marco Kittel"
                        },
                        new
                        {
                            Id = 21,
                            BenutzerId = 2,
                            Beschreibung = "Keller",
                            CreatedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(2000),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(2000),
                            Name = "KE",
                            UpdatedBy = "Marco Kittel"
                        });
                });

            modelBuilder.Entity("Marmelade.Data.Lagergegenstand", b =>
                {
                    b.HasOne("Marmelade.Data.Benutzer", "Benutzer")
                        .WithMany("Lagergegenstand")
                        .HasForeignKey("BenutzerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marmelade.Data.Lagerort", "Lagerort")
                        .WithMany("Lagergegenstand")
                        .HasForeignKey("LagerortId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Benutzer");

                    b.Navigation("Lagerort");
                });

            modelBuilder.Entity("Marmelade.Data.Lagerort", b =>
                {
                    b.HasOne("Marmelade.Data.Benutzer", "Benutzer")
                        .WithMany("Lagerort")
                        .HasForeignKey("BenutzerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Benutzer");
                });

            modelBuilder.Entity("Marmelade.Data.Benutzer", b =>
                {
                    b.Navigation("Lagergegenstand");

                    b.Navigation("Lagerort");
                });

            modelBuilder.Entity("Marmelade.Data.Lagerort", b =>
                {
                    b.Navigation("Lagergegenstand");
                });
#pragma warning restore 612, 618
        }
    }
}
