using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marmelade.Data.Migrations
{
    /// <inheritdoc />
    public partial class _2nd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApiEinstellungen",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(7090), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(7090) });

            migrationBuilder.UpdateData(
                table: "Lagergegenstand",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Beschreibung", "CreatedAt", "Lagerzeitpunkt", "ModifiedAt", "Name" },
                values: new object[] { "Frische Fruchtmarmelade", new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6330), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6370), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6360), "Melonen Marmelade" });

            migrationBuilder.InsertData(
                table: "Lagergegenstand",
                columns: new[] { "Id", "Beschreibung", "CreatedAt", "CreatedBy", "LagerortId", "Lagerzeitpunkt", "Menge", "Mengenbezeichner", "ModifiedAt", "Name", "UpdatedBy" },
                values: new object[] { 2, "Frische Fruchtmarmelade", new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6370), "Marco Kittel", 5, new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6370), 750.0, "Gramm", new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6370), "Erdbeer Marmelade", "Marco Kittel" });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6450), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6450) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6460), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6460) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6460), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6460) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6460), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6460) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6470), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6470) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6470), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6470) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6470), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6480) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6480), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6480) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6480), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6480) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6490), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6490), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6500), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6500), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6500), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6510), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6510) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6510), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6510) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6510), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6510) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6520), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6530), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6530), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6530), new DateTime(2023, 12, 15, 19, 51, 27, 377, DateTimeKind.Local).AddTicks(6530) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lagergegenstand",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "ApiEinstellungen",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7820), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7820) });

            migrationBuilder.UpdateData(
                table: "Lagergegenstand",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Beschreibung", "CreatedAt", "Lagerzeitpunkt", "ModifiedAt", "Name" },
                values: new object[] { "", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7070), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7110), "Marmelade" });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7180), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7180) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7190), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7190) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7190), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7190) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7200), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7200), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7200), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7210), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7210), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7220), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7220), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7220), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7230), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7230), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7240), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7240) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7240), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7240) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7240), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7240) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7250), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7280), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7280) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7290), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7290) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7290), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7290) });

            migrationBuilder.UpdateData(
                table: "Lagerorte",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7290), new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7290) });
        }
    }
}
