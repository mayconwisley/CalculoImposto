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
            values: new object[] { new Guid("bfa5e22d-0688-4c0b-88c3-828e0d9202eb"), new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 189.59m });

        migrationBuilder.InsertData(
            table: "DescontoMinimo",
            columns: new[] { "Id", "Competence", "Value" },
            values: new object[] { new Guid("0441894f-fa4b-45ec-b9b6-c992ea9763a6"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10m });

        migrationBuilder.InsertData(
            table: "Inss",
            columns: new[] { "Id", "Competence", "Percent", "Range", "Value" },
            values: new object[,]
            {
                { new Guid("06fb76d6-c14b-4eaf-af1a-5180d4bee488"), new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.5m, 1, 1045.00m },
                { new Guid("1cf40be4-4a34-4894-b679-653c10b7a7a2"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9m, 2, 2571.29m },
                { new Guid("1d1a159e-ea80-4e2b-b2b9-f3bd3a64a0ad"), new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9m, 2, 2089.60m },
                { new Guid("2699e354-a7b6-4e6f-9c89-10cb63b6a51f"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.5m, 1, 1320.00m },
                { new Guid("32379205-7ee1-4fe1-b3c8-f9e7c3bcc443"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14m, 4, 7507.49m },
                { new Guid("3621735d-242e-430f-abaf-36fd19f26ba4"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14m, 4, 7087.22m },
                { new Guid("3ae4f324-9e4d-4763-ba7f-5ef36de7a60c"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, 3, 4190.83m },
                { new Guid("522076f9-37f0-449c-85b6-53a19367c9f8"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.5m, 1, 1212.00m },
                { new Guid("52a39bc8-1094-48aa-849d-ba1720fe8464"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9m, 2, 2666.68m },
                { new Guid("64ef6174-9bea-432f-83b1-837bf018c70c"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, 3, 4000.03m },
                { new Guid("7ec363e9-0019-4f69-9e0a-441c6424c48d"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.5m, 1, 1302.00m },
                { new Guid("8ef9c1d1-b976-4882-8835-cd1774e8ede0"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9m, 2, 2571.29m },
                { new Guid("9089029d-a720-424f-933e-1185bd6cfb75"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14m, 4, 7786.02m },
                { new Guid("9184caba-60df-4b36-9ac8-9a4d9650243a"), new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14m, 4, 6101.06m },
                { new Guid("97ba531f-fc3d-4316-bb02-6e9fdf5130e5"), new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, 3, 3134.40m },
                { new Guid("9c93a24a-e1a1-43a2-a95b-a2015ec147b8"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, 3, 3679.00m },
                { new Guid("a84980ca-ffb5-4841-a659-1d287c84b6ac"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14m, 4, 8157.41m },
                { new Guid("c1dd95c8-b624-48f1-b7e8-fbc0b0b4a16e"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, 3, 3856.94m },
                { new Guid("cbcfd40e-46c1-40ac-9029-06f7b951d418"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14m, 4, 7507.49m },
                { new Guid("d15e654a-abc2-47fd-81a7-e620264c4d4c"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, 3, 3856.94m },
                { new Guid("d7eac449-cc29-4108-842e-b6bb2e689231"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9m, 2, 2793.88m },
                { new Guid("d854e1c7-86af-43c1-b39c-947e4144076d"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9m, 2, 2452.67m },
                { new Guid("defdc03a-0c30-491e-b627-96e16be5f0d8"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.5m, 1, 1518.00m },
                { new Guid("e6324c1f-465d-454e-9b01-6a3c28c354b2"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.5m, 1, 1412.00m }
            });

        migrationBuilder.InsertData(
            table: "Irrf",
            columns: new[] { "Id", "Competence", "Deduction", "Percent", "Range", "Value" },
            values: new object[,]
            {
                { new Guid("11ef9768-983d-42ee-96fd-27f84707dcd9"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 896.00m, 27.50m, 5, 99999999999.99m },
                { new Guid("39ce6a17-8749-4f02-ae4e-0731c7225e7f"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 370.40m, 15m, 3, 3751.05m },
                { new Guid("3fa92be7-a944-46d8-9771-1cc947357619"), new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 1, 1903.98m },
                { new Guid("43c4ae8b-5d5c-44b3-b71a-52b95673fb6d"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 169.44m, 7.50m, 2, 2826.65m },
                { new Guid("474fa28a-8c6f-44a5-8b85-2528837df526"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 381.44m, 15m, 3, 3751.05m },
                { new Guid("534f8981-fd71-40ae-ba18-dca32699ee7b"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 884.96m, 27.50m, 5, 99999999999.99m },
                { new Guid("553eb4c1-867a-4289-ade4-7918c8f3ffdd"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 662.77m, 22.50m, 4, 4664.68m },
                { new Guid("5f7acfef-f69b-42cf-bb63-5aabf267346c"), new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 869.36m, 27.50m, 5, 99999999999.99m },
                { new Guid("6261e0f2-bdd3-4bef-9dc3-21e7bebd0cec"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 1, 2112.00m },
                { new Guid("6ded96d0-a5ad-4bf4-aa4a-125b2961d728"), new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 636.13m, 22.50m, 4, 4664.68m },
                { new Guid("77c42494-30a9-4e9c-aacd-02eb69b0f7c6"), new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 142.80m, 7.50m, 2, 2826.65m },
                { new Guid("844ae8fd-7879-4b6f-ac93-bc1859128c65"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 1, 2259.20m },
                { new Guid("bb940995-0624-41b3-9f79-1c027665f5b7"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 651.73m, 22.50m, 4, 4664.68m },
                { new Guid("c0dc33a5-4a18-4f67-9e5f-2222fe7d9355"), new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 354.80m, 15m, 3, 3751.05m },
                { new Guid("d64284dc-ccd2-4e84-9540-20297356a151"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 158.40m, 7.50m, 2, 2826.65m }
            });

        migrationBuilder.InsertData(
            table: "Simplificado",
            columns: new[] { "Id", "Competence", "Value" },
            values: new object[,]
            {
                { new Guid("368acce8-c097-495c-b28b-3b6ab4285219"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 528.00m },
                { new Guid("93fa5b6d-5bdf-4380-af47-523c3bbda1b9"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 564.80m }
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
