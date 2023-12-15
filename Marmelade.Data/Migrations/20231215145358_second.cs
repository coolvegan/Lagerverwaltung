using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marmelade.Data.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Lagergegenstand",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Menge", "Mengenbezeichner", "ModifiedAt", "Name" },
                values: new object[] { new DateTime(2023, 12, 15, 15, 53, 57, 972, DateTimeKind.Local).AddTicks(1730), 500.0, "Gramm", new DateTime(2023, 12, 15, 15, 53, 57, 972, DateTimeKind.Local).AddTicks(1730), "Marmelade" });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 15, 53, 57, 972, DateTimeKind.Local).AddTicks(1580), new DateTime(2023, 12, 15, 15, 53, 57, 972, DateTimeKind.Local).AddTicks(1620) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Lagergegenstand",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Menge", "Mengenbezeichner", "ModifiedAt", "Name" },
                values: new object[] { new DateTime(2023, 12, 15, 15, 41, 26, 926, DateTimeKind.Local).AddTicks(4290), 0.0, "", new DateTime(2023, 12, 15, 15, 41, 26, 926, DateTimeKind.Local).AddTicks(4300), "A1" });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 15, 41, 26, 926, DateTimeKind.Local).AddTicks(4150), new DateTime(2023, 12, 15, 15, 41, 26, 926, DateTimeKind.Local).AddTicks(4180) });
        }
    }
}
