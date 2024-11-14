using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EjermploConversorMoneda.Migrations
{
    /// <inheritdoc />
    public partial class AppDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monedas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Simbolo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monedas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodigoISO = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Capital = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PrefijoTelefonico = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactoresConversion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonedaOrigenId = table.Column<int>(type: "int", nullable: false),
                    MonedaDestinoId = table.Column<int>(type: "int", nullable: false),
                    Factor = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoresConversion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactoresConversion_Monedas_MonedaDestinoId",
                        column: x => x.MonedaDestinoId,
                        principalTable: "Monedas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FactoresConversion_Monedas_MonedaOrigenId",
                        column: x => x.MonedaOrigenId,
                        principalTable: "Monedas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaisId = table.Column<int>(type: "int", nullable: true),
                    IdentityUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HistorialConversiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    MonedaOrigenId = table.Column<int>(type: "int", nullable: false),
                    MonedaDestinoId = table.Column<int>(type: "int", nullable: false),
                    FactorConversionUsado = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Importe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Resultado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaConversion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialConversiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialConversiones_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistorialConversiones_Monedas_MonedaDestinoId",
                        column: x => x.MonedaDestinoId,
                        principalTable: "Monedas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistorialConversiones_Monedas_MonedaOrigenId",
                        column: x => x.MonedaOrigenId,
                        principalTable: "Monedas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PaisId",
                table: "Clientes",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoresConversion_MonedaDestinoId",
                table: "FactoresConversion",
                column: "MonedaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoresConversion_MonedaOrigenId",
                table: "FactoresConversion",
                column: "MonedaOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialConversiones_ClienteId",
                table: "HistorialConversiones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialConversiones_MonedaDestinoId",
                table: "HistorialConversiones",
                column: "MonedaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialConversiones_MonedaOrigenId",
                table: "HistorialConversiones",
                column: "MonedaOrigenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactoresConversion");

            migrationBuilder.DropTable(
                name: "HistorialConversiones");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Monedas");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
