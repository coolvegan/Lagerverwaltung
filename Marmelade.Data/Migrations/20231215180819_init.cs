using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Marmelade.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiEinstellungen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthenticationSchluessel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiEinstellungen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lagerorte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Beschreibung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lagerorte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lagergegenstand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beschreibung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mengenbezeichner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LagerortId = table.Column<int>(type: "int", nullable: false),
                    Menge = table.Column<double>(type: "float", nullable: false),
                    Lagerzeitpunkt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lagergegenstand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lagergegenstand_Lagerorte_LagerortId",
                        column: x => x.LagerortId,
                        principalTable: "Lagerorte",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ApiEinstellungen",
                columns: new[] { "Id", "AuthenticationSchluessel", "CreatedAt", "CreatedBy", "ModifiedAt", "UpdatedBy" },
                values: new object[] { 1, "ChangeMe", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7820), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7820), "Marco Kittel" });

            migrationBuilder.InsertData(
                table: "Lagerorte",
                columns: new[] { "Id", "Beschreibung", "CreatedAt", "CreatedBy", "ModifiedAt", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "Kühlschrank A", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7180), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7180), "A1", "Marco Kittel" },
                    { 2, "Kühlschrank A", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7190), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7190), "A2", "Marco Kittel" },
                    { 3, "Kühlschrank A", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7190), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7190), "A3", "Marco Kittel" },
                    { 4, "Kühlschrank A", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7200), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7200), "A4", "Marco Kittel" },
                    { 5, "Kühlschrank A", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7200), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7200), "A5", "Marco Kittel" },
                    { 6, "Kühlschrank A", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7200), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7210), "A6", "Marco Kittel" },
                    { 7, "Kühlschrank B", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7210), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7210), "B1", "Marco Kittel" },
                    { 8, "Kühlschrank B", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7210), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7220), "B2", "Marco Kittel" },
                    { 9, "Kühlschrank B", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7220), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7220), "B3", "Marco Kittel" },
                    { 10, "Kühlschrank B", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7220), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7220), "B4", "Marco Kittel" },
                    { 11, "Kühlschrank B", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7220), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7230), "B5", "Marco Kittel" },
                    { 12, "Kühlschrank B", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7230), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7230), "B6", "Marco Kittel" },
                    { 13, "Kühlschrank C", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7230), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7230), "C1", "Marco Kittel" },
                    { 14, "Kühlschrank C", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7240), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7240), "C2", "Marco Kittel" },
                    { 15, "Kühlschrank C", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7240), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7240), "C3", "Marco Kittel" },
                    { 16, "Kühlschrank C", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7240), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7240), "C4", "Marco Kittel" },
                    { 17, "Kühlschrank C", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7250), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7250), "C5", "Marco Kittel" },
                    { 18, "Kühlschrank G", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7280), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7280), "G1", "Marco Kittel" },
                    { 19, "Kühlschrank G", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7290), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7290), "G2", "Marco Kittel" },
                    { 20, "Garage", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7290), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7290), "GA", "Marco Kittel" },
                    { 21, "Keller", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7290), "Marco Kittel", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7290), "KE", "Marco Kittel" }
                });

            migrationBuilder.InsertData(
                table: "Lagergegenstand",
                columns: new[] { "Id", "Beschreibung", "CreatedAt", "CreatedBy", "LagerortId", "Lagerzeitpunkt", "Menge", "Mengenbezeichner", "ModifiedAt", "Name", "UpdatedBy" },
                values: new object[] { 1, "", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7070), "Marco Kittel", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0, "Gramm", new DateTime(2023, 12, 15, 19, 8, 19, 595, DateTimeKind.Local).AddTicks(7110), "Marmelade", "Marco Kittel" });

            migrationBuilder.CreateIndex(
                name: "IX_Lagergegenstand_LagerortId",
                table: "Lagergegenstand",
                column: "LagerortId");

            migrationBuilder.CreateIndex(
                name: "IX_Lagerorte_Name",
                table: "Lagerorte",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiEinstellungen");

            migrationBuilder.DropTable(
                name: "Lagergegenstand");

            migrationBuilder.DropTable(
                name: "Lagerorte");
        }
    }
}
