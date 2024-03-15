using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculoImposto.API.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dependentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Competencia = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DescontoMinimos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Competencia = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescontoMinimos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "INSS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Faixa = table.Column<int>(type: "int", nullable: false),
                    Porcentagem = table.Column<decimal>(type: "DECIMAL(7,4)", nullable: false),
                    Teto = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Competencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IRRF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Faixa = table.Column<int>(type: "int", nullable: false),
                    Porcentagem = table.Column<decimal>(type: "DECIMAL(7,4)", nullable: false),
                    Deducao = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Competencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IRRF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Simplificados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Competencia = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simplificados", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependentes");

            migrationBuilder.DropTable(
                name: "DescontoMinimos");

            migrationBuilder.DropTable(
                name: "INSS");

            migrationBuilder.DropTable(
                name: "IRRF");

            migrationBuilder.DropTable(
                name: "Simplificados");
        }
    }
}
