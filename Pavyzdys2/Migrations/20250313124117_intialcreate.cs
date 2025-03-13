using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pavyzdys2.Migrations
{
    /// <inheritdoc />
    public partial class intialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automobiliai",
                columns: table => new
                {
                    AutomobilioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PirmosRegData = table.Column<DateOnly>(type: "date", nullable: false),
                    ParosKaina = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobiliai", x => x.AutomobilioId);
                });

            migrationBuilder.CreateTable(
                name: "Klientai",
                columns: table => new
                {
                    KlientoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AsmensKodas = table.Column<long>(type: "bigint", nullable: false),
                    VardasPavarde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NuomuojamasAutoAutomobilioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klientai", x => x.KlientoId);
                    table.ForeignKey(
                        name: "FK_Klientai_Automobiliai_NuomuojamasAutoAutomobilioId",
                        column: x => x.NuomuojamasAutoAutomobilioId,
                        principalTable: "Automobiliai",
                        principalColumn: "AutomobilioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Klientai_NuomuojamasAutoAutomobilioId",
                table: "Klientai",
                column: "NuomuojamasAutoAutomobilioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klientai");

            migrationBuilder.DropTable(
                name: "Automobiliai");
        }
    }
}
