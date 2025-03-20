using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculoImposto.Api.Migrations;

/// <inheritdoc />
public partial class v1 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Dependente",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Competencia = table.Column<DateTime>(type: "DATE", nullable: false),
                Valor = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Dependente", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "DescontoMinimo",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Competencia = table.Column<DateTime>(type: "DATE", nullable: false),
                Valor = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DescontoMinimo", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Inss",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Faixa = table.Column<int>(type: "INTEGER", nullable: false),
                Porcentagem = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                Competencia = table.Column<DateTime>(type: "DATE", nullable: false),
                Valor = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Inss", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Irrf",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Faixa = table.Column<int>(type: "INTEGER", nullable: false),
                Porcentagem = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                Deducao = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                Competencia = table.Column<DateTime>(type: "DATE", nullable: false),
                Valor = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Irrf", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Simplificado",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Competencia = table.Column<DateTime>(type: "DATE", nullable: false),
                Valor = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Simplificado", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Dependente");

        migrationBuilder.DropTable(
            name: "DescontoMinimo");

        migrationBuilder.DropTable(
            name: "Inss");

        migrationBuilder.DropTable(
            name: "Irrf");

        migrationBuilder.DropTable(
            name: "Simplificado");
    }
}
