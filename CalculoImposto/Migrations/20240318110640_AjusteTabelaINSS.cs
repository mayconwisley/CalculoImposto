using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculoImposto.API.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTabelaINSS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Teto",
                table: "INSS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Teto",
                table: "INSS",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
