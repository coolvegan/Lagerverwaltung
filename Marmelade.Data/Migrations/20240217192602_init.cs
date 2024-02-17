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
                name: "Benutzer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benutzer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lagerorte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Beschreibung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BenutzerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lagerorte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lagerorte_Benutzer_BenutzerId",
                        column: x => x.BenutzerId,
                        principalTable: "Benutzer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    BenutzerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lagergegenstand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lagergegenstand_Benutzer_BenutzerId",
                        column: x => x.BenutzerId,
                        principalTable: "Benutzer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lagergegenstand_Lagerorte_LagerortId",
                        column: x => x.LagerortId,
                        principalTable: "Lagerorte",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ApiEinstellungen",
                columns: new[] { "Id", "AuthenticationSchluessel", "CreatedAt", "CreatedBy", "ModifiedAt", "UpdatedBy" },
                values: new object[] { 1, "ChangeMe", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1280), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1320), "Marco Kittel" });

            migrationBuilder.InsertData(
                table: "Benutzer",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ModifiedAt", "Name", "Password", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1490), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1490), "paul", "63b4f9e2e7cc082b0eb953d998b0d7137fb8970f8de2fa594e3338449f512511", "Marco Kittel" },
                    { 2, new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1760), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1760), "peter", "93d8057a6c851b1f0e0038fd660f6ed563c6f56067b8c8f05da6022218d79e3b", "Marco Kittel" }
                });

            migrationBuilder.InsertData(
                table: "Lagerorte",
                columns: new[] { "Id", "BenutzerId", "Beschreibung", "CreatedAt", "CreatedBy", "ModifiedAt", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 2, "Kühlschrank A", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1910), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1910), "A1", "Marco Kittel" },
                    { 2, 2, "Kühlschrank A", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1930), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1930), "A2", "Marco Kittel" },
                    { 3, 2, "Kühlschrank A", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1930), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1930), "A3", "Marco Kittel" },
                    { 4, 2, "Kühlschrank A", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1930), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1930), "A4", "Marco Kittel" },
                    { 5, 2, "Kühlschrank A", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1940), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1940), "A5", "Marco Kittel" },
                    { 6, 2, "Kühlschrank A", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1940), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1940), "A6", "Marco Kittel" },
                    { 7, 2, "Kühlschrank B", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1950), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1950), "B1", "Marco Kittel" },
                    { 8, 2, "Kühlschrank B", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1950), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1950), "B2", "Marco Kittel" },
                    { 9, 2, "Kühlschrank B", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1950), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1950), "B3", "Marco Kittel" },
                    { 10, 2, "Kühlschrank B", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1960), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1960), "B4", "Marco Kittel" },
                    { 11, 2, "Kühlschrank B", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1960), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1960), "B5", "Marco Kittel" },
                    { 12, 2, "Kühlschrank B", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1960), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1960), "B6", "Marco Kittel" },
                    { 13, 2, "Kühlschrank C", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1970), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1970), "C1", "Marco Kittel" },
                    { 14, 2, "Kühlschrank C", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1970), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1970), "C2", "Marco Kittel" },
                    { 15, 2, "Kühlschrank C", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1970), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1970), "C3", "Marco Kittel" },
                    { 16, 2, "Kühlschrank C", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1980), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1980), "C4", "Marco Kittel" },
                    { 17, 2, "Kühlschrank C", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1980), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1980), "C5", "Marco Kittel" },
                    { 18, 2, "Kühlschrank G", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1990), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1990), "G1", "Marco Kittel" },
                    { 19, 2, "Kühlschrank G", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(2000), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(2000), "G2", "Marco Kittel" },
                    { 20, 2, "Garage", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(2000), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(2000), "GA", "Marco Kittel" },
                    { 21, 2, "Keller", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(2000), "Marco Kittel", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(2000), "KE", "Marco Kittel" }
                });

            migrationBuilder.InsertData(
                table: "Lagergegenstand",
                columns: new[] { "Id", "BenutzerId", "Beschreibung", "CreatedAt", "CreatedBy", "LagerortId", "Lagerzeitpunkt", "Menge", "Mengenbezeichner", "ModifiedAt", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 2, "Frische Fruchtmarmelade", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1890), "Marco Kittel", 1, new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1890), 500.0, "Gramm", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1890), "Melonen Marmelade", "Marco Kittel" },
                    { 2, 2, "Frische Fruchtmarmelade", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1900), "Marco Kittel", 5, new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1900), 750.0, "Gramm", new DateTime(2024, 2, 17, 20, 26, 2, 566, DateTimeKind.Local).AddTicks(1900), "Erdbeer Marmelade", "Marco Kittel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lagergegenstand_BenutzerId",
                table: "Lagergegenstand",
                column: "BenutzerId");

            migrationBuilder.CreateIndex(
                name: "IX_Lagergegenstand_LagerortId",
                table: "Lagergegenstand",
                column: "LagerortId");

            migrationBuilder.CreateIndex(
                name: "IX_Lagerorte_BenutzerId",
                table: "Lagerorte",
                column: "BenutzerId");

            migrationBuilder.CreateIndex(
                name: "IX_Lagerorte_Name_BenutzerId",
                table: "Lagerorte",
                columns: new[] { "Name", "BenutzerId" },
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

            migrationBuilder.DropTable(
                name: "Benutzer");
        }
    }
}
