using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CalculoImposto.Api.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Dependente",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Competence = table.Column<DateTime>(type: "DATE", nullable: false),
                Value = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
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
                Competence = table.Column<DateTime>(type: "DATE", nullable: false),
                Value = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
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
                Range = table.Column<int>(type: "INTEGER", nullable: false),
                Percent = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                Competence = table.Column<DateTime>(type: "DATE", nullable: false),
                Value = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
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
                Range = table.Column<int>(type: "INTEGER", nullable: false),
                Percent = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                Deduction = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                Competence = table.Column<DateTime>(type: "DATE", nullable: false),
                Value = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
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
                Competence = table.Column<DateTime>(type: "DATE", nullable: false),
                Value = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Simplificado", x => x.Id);
            });

        migrationBuilder.InsertData(
            table: "Dependente",
            columns: new[] { "Id", "Competence", "Value" },
            values: new object[] { new Guid("b8738c50-3292-4ecb-af01-57cb7d62f97a"), new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 189.59m });

        migrationBuilder.InsertData(
            table: "DescontoMinimo",
            columns: new[] { "Id", "Competence", "Value" },
            values: new object[] { new Guid("7f1b5cb3-cc50-4b61-a069-23c8405ff803"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10m });

        migrationBuilder.InsertData(
            table: "Inss",
            columns: new[] { "Id", "Competence", "Percent", "Range", "Value" },
            values: new object[,]
            {
                { new Guid("0d1b0e2f-fb2e-4bca-a16a-cda0ee17b065"), new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.5m, 1, 1045.00m },
                { new Guid("122b3a2e-3c79-4348-9242-ac850e0c4a32"), new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9m, 2, 2089.60m },
                { new Guid("14c8001b-7cd8-410e-ab7f-a93662b3989f"), new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, 3, 3134.40m },
                { new Guid("21a3f856-5d86-453d-b0ae-6181be43df06"), new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14m, 4, 6101.06m },
                { new Guid("29628231-f502-4915-acc9-0586be47a9e8"), new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.5m, 1, 1100.00m },
                { new Guid("30144cb3-8953-452e-8df4-38a49192fd0c"), new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9m, 2, 2203.45m },
                { new Guid("37e3a79f-8fad-4d56-9c74-90d71677f81e"), new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, 3, 3305.22m },
                { new Guid("39ff5d25-7edb-463a-8321-a41bdda2fc34"), new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14m, 4, 6433.57m },
                { new Guid("3e2f48e0-0383-4e83-ac00-146830b3d4a5"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.5m, 1, 1212.00m },
                { new Guid("493755aa-215d-4b58-a89e-c64149aa195d"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9m, 2, 2452.67m },
                { new Guid("59c34449-05ad-4d37-8e31-0a6b8919d784"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, 3, 3679.00m },
                { new Guid("6c8bfacf-b487-45f0-9fac-07019f049b65"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14m, 4, 7087.22m },
                { new Guid("71918e26-9e1a-45be-b506-eef4c4d8fde3"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.5m, 1, 1302.00m },
                { new Guid("7df80acf-f350-4678-afc6-24b579494b72"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9m, 2, 2571.29m },
                { new Guid("9cecf50d-d733-41a6-bc36-44d6fcc1b58c"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, 3, 3856.94m },
                { new Guid("a9247c53-f0f5-4894-9c08-9b47f439a36a"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14m, 4, 7507.49m },
                { new Guid("b2a14b29-cc63-4c87-8c73-18a2807aa080"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.5m, 1, 1320.00m },
                { new Guid("b4e4897a-273c-4818-8767-01ca459804b1"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9m, 2, 2571.29m },
                { new Guid("cb0473b9-f774-4b2a-98e5-da8a255cfd45"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, 3, 3856.94m },
                { new Guid("d1c8f535-70ab-4ca4-9089-67302851495c"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14m, 4, 7507.49m },
                { new Guid("d5fbdfeb-a8c3-42d5-812c-872d65588c82"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.5m, 1, 1412.00m },
                { new Guid("d91884b0-cc69-46e3-8e5f-89d4dcb4d39e"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9m, 2, 2666.68m },
                { new Guid("e5545b95-0f49-457d-a958-f4bc65caa6cd"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, 3, 4000.03m },
                { new Guid("eb204e7a-5a7f-44e0-9224-833b74f4c173"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14m, 4, 7786.02m },
                { new Guid("f5c4d84a-2e79-47ea-9949-e9f4ede99ce8"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.5m, 1, 1518.00m },
                { new Guid("fd49c72a-8b9d-4221-a144-0acc75ab3b44"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9m, 2, 2793.88m },
                { new Guid("ff88a34a-9fa4-47b6-996e-41bb5c9bd374"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, 3, 4190.83m },
                { new Guid("ff8b28ec-a94f-4291-ae7d-2ac3de353ce1"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14m, 4, 8157.41m }
            });

        migrationBuilder.InsertData(
            table: "Irrf",
            columns: new[] { "Id", "Competence", "Deduction", "Percent", "Range", "Value" },
            values: new object[,]
            {
                { new Guid("145774d6-2289-42d0-9060-2cb73a3681c6"), new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 1, 1903.98m },
                { new Guid("19833513-67a2-4db5-91f5-ec212bd5e397"), new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 142.80m, 7.50m, 2, 2826.65m },
                { new Guid("23dcc1ce-cdff-424a-ba82-caf29591244c"), new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 354.80m, 15m, 3, 3751.05m },
                { new Guid("3d6487f9-8c14-475a-bda2-8346ca65baaa"), new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 636.13m, 22.50m, 4, 4664.68m },
                { new Guid("473a63a2-b1a0-4721-bee4-5fbc3d27a7e3"), new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 869.36m, 27.50m, 5, 99999999999.99m },
                { new Guid("5489d21d-c596-486e-a506-e77589fc9989"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 1, 2112.00m },
                { new Guid("7468fb2e-58bb-4e4b-bbc6-9de0e87438ea"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 158.40m, 7.50m, 2, 2826.65m },
                { new Guid("7d50c7d0-6576-4f6c-b348-017062ad5837"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 370.40m, 15m, 3, 3751.05m },
                { new Guid("9c978ea5-472a-4e71-a082-73a5d5d99b74"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 651.73m, 22.50m, 4, 4664.68m },
                { new Guid("9fe85d20-3fd8-4e62-90ba-2807eaa9abf3"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 884.96m, 27.50m, 5, 99999999999.99m },
                { new Guid("a7df5997-6db5-4a51-8da1-a0703ac05ecd"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 1, 2259.20m },
                { new Guid("affd90a2-0372-45ff-af40-ee69d3e343a0"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 169.44m, 7.50m, 2, 2826.65m },
                { new Guid("bcab32f7-35f1-4dc4-898c-2d36ee0af95c"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 381.44m, 15m, 3, 3751.05m },
                { new Guid("eed864b0-2bc9-455c-beb8-bae000da7077"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 662.77m, 22.50m, 4, 4664.68m },
                { new Guid("f544a765-e333-4242-aa9a-c7bece8efed8"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 896.00m, 27.50m, 5, 99999999999.99m }
            });

        migrationBuilder.InsertData(
            table: "Simplificado",
            columns: new[] { "Id", "Competence", "Value" },
            values: new object[,]
            {
                { new Guid("300ec55a-a5b0-411b-be64-627db7608037"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 528.00m },
                { new Guid("9db4331e-9735-403d-b2f7-6bbeb8942556"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 564.80m }
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
