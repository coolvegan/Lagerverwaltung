﻿// <auto-generated />
using System;
using Marmelade.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Marmelade.Data.Migrations
{
    [DbContext(typeof(DatenbankContext))]
    partial class DatenbankContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                });

            modelBuilder.Entity("Marmelade.Data.Lagergegenstand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.HasIndex("LagerortId");

                    b.ToTable("Lagergegenstand");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Beschreibung = "",
                            CreatedAt = new DateTime(2023, 12, 15, 15, 53, 57, 972, DateTimeKind.Local).AddTicks(1730),
                            CreatedBy = "Marco Kittel",
                            LagerortId = 1,
                            Lagerzeitpunkt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Menge = 500.0,
                            Mengenbezeichner = "Gramm",
                            ModifiedAt = new DateTime(2023, 12, 15, 15, 53, 57, 972, DateTimeKind.Local).AddTicks(1730),
                            Name = "Marmelade",
                            UpdatedBy = "Marco Kittel"
                        });
                });

            modelBuilder.Entity("Marmelade.Data.Lagerort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Lagerorte");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Beschreibung = "",
                            CreatedAt = new DateTime(2023, 12, 15, 15, 53, 57, 972, DateTimeKind.Local).AddTicks(1580),
                            CreatedBy = "Marco Kittel",
                            ModifiedAt = new DateTime(2023, 12, 15, 15, 53, 57, 972, DateTimeKind.Local).AddTicks(1620),
                            Name = "A1",
                            UpdatedBy = "Marco Kittel"
                        });
                });

            modelBuilder.Entity("Marmelade.Data.Lagergegenstand", b =>
                {
                    b.HasOne("Marmelade.Data.Lagerort", "Lagerort")
                        .WithMany("Lagergegenstand")
                        .HasForeignKey("LagerortId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

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
