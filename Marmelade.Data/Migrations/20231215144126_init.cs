using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                table: "Lagerorte",
                columns: new[] { "Id", "Beschreibung", "CreatedAt", "CreatedBy", "ModifiedAt", "Name", "UpdatedBy" },
                values: new object[] { 1, "", new DateTime(2023, 12, 15, 15, 41, 26, 926, DateTimeKind.Local).AddTicks(4150), "Marco Kittel", new DateTime(2023, 12, 15, 15, 41, 26, 926, DateTimeKind.Local).AddTicks(4180), "A1", "Marco Kittel" });

            migrationBuilder.InsertData(
                table: "Lagergegenstand",
                columns: new[] { "Id", "Beschreibung", "CreatedAt", "CreatedBy", "LagerortId", "Lagerzeitpunkt", "Menge", "Mengenbezeichner", "ModifiedAt", "Name", "UpdatedBy" },
                values: new object[] { 1, "", new DateTime(2023, 12, 15, 15, 41, 26, 926, DateTimeKind.Local).AddTicks(4290), "Marco Kittel", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0, "", new DateTime(2023, 12, 15, 15, 41, 26, 926, DateTimeKind.Local).AddTicks(4300), "A1", "Marco Kittel" });

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
