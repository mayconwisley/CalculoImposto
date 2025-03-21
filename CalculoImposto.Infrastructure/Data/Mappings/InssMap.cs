using CalculoImposto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalculoImposto.Infrastructure.Data.Mappings;

public class InssMap : IEntityTypeConfiguration<Inss>
{
    public void Configure(EntityTypeBuilder<Inss> builder)
    {
        builder.ToTable("Inss");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Competence)
            .HasColumnType("DATE")
            .IsRequired();
        builder.Property(x => x.Value)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();
        builder.Property(x => x.Range)
            .HasColumnType("INTEGER")
            .IsRequired();
        builder.Property(x => x.Percent)
            .HasColumnType("DECIMAL(5,2)")
            .IsRequired();

        builder.HasData(
                new Inss { Id = new Guid("0d1b0e2f-fb2e-4bca-a16a-cda0ee17b065"), Range = 1, Value = 1045.00m, Percent = 7.5m, Competence = DateTime.Parse("01/03/2020") },
                new Inss { Id = new Guid("122b3a2e-3c79-4348-9242-ac850e0c4a32"), Range = 2, Value = 2089.60m, Percent = 9m, Competence = DateTime.Parse("01/03/2020") },
                new Inss { Id = new Guid("14c8001b-7cd8-410e-ab7f-a93662b3989f"), Range = 3, Value = 3134.40m, Percent = 12m, Competence = DateTime.Parse("01/03/2020") },
                new Inss { Id = new Guid("21a3f856-5d86-453d-b0ae-6181be43df06"), Range = 4, Value = 6101.06m, Percent = 14m, Competence = DateTime.Parse("01/03/2020") },
                new Inss { Id = new Guid("29628231-f502-4915-acc9-0586be47a9e8"), Range = 1, Value = 1100.00m, Percent = 7.5m, Competence = DateTime.Parse("01/03/2021") },
                new Inss { Id = new Guid("30144cb3-8953-452e-8df4-38a49192fd0c"), Range = 2, Value = 2203.45m, Percent = 9m, Competence = DateTime.Parse("01/03/2021") },
                new Inss { Id = new Guid("37e3a79f-8fad-4d56-9c74-90d71677f81e"), Range = 3, Value = 3305.22m, Percent = 12m, Competence = DateTime.Parse("01/03/2021") },
                new Inss { Id = new Guid("39ff5d25-7edb-463a-8321-a41bdda2fc34"), Range = 4, Value = 6433.57m, Percent = 14m, Competence = DateTime.Parse("01/03/2021") },
                new Inss { Id = new Guid("3e2f48e0-0383-4e83-ac00-146830b3d4a5"), Range = 1, Value = 1212.00m, Percent = 7.5m, Competence = DateTime.Parse("01/01/2022") },
                new Inss { Id = new Guid("493755aa-215d-4b58-a89e-c64149aa195d"), Range = 2, Value = 2452.67m, Percent = 9m, Competence = DateTime.Parse("01/01/2022") },
                new Inss { Id = new Guid("59c34449-05ad-4d37-8e31-0a6b8919d784"), Range = 3, Value = 3679.00m, Percent = 12m, Competence = DateTime.Parse("01/01/2022") },
                new Inss { Id = new Guid("6c8bfacf-b487-45f0-9fac-07019f049b65"), Range = 4, Value = 7087.22m, Percent = 14m, Competence = DateTime.Parse("01/01/2022") },
                new Inss { Id = new Guid("71918e26-9e1a-45be-b506-eef4c4d8fde3"), Range = 1, Value = 1302.00m, Percent = 7.5m, Competence = DateTime.Parse("01/01/2023") },
                new Inss { Id = new Guid("7df80acf-f350-4678-afc6-24b579494b72"), Range = 2, Value = 2571.29m, Percent = 9m, Competence = DateTime.Parse("01/01/2023") },
                new Inss { Id = new Guid("9cecf50d-d733-41a6-bc36-44d6fcc1b58c"), Range = 3, Value = 3856.94m, Percent = 12m, Competence = DateTime.Parse("01/01/2023") },
                new Inss { Id = new Guid("a9247c53-f0f5-4894-9c08-9b47f439a36a"), Range = 4, Value = 7507.49m, Percent = 14m, Competence = DateTime.Parse("01/01/2023") },
                new Inss { Id = new Guid("b2a14b29-cc63-4c87-8c73-18a2807aa080"), Range = 1, Value = 1320.00m, Percent = 7.5m, Competence = DateTime.Parse("01/05/2023") },
                new Inss { Id = new Guid("b4e4897a-273c-4818-8767-01ca459804b1"), Range = 2, Value = 2571.29m, Percent = 9m, Competence = DateTime.Parse("01/05/2023") },
                new Inss { Id = new Guid("cb0473b9-f774-4b2a-98e5-da8a255cfd45"), Range = 3, Value = 3856.94m, Percent = 12m, Competence = DateTime.Parse("01/05/2023") },
                new Inss { Id = new Guid("d1c8f535-70ab-4ca4-9089-67302851495c"), Range = 4, Value = 7507.49m, Percent = 14m, Competence = DateTime.Parse("01/05/2023") },
                new Inss { Id = new Guid("d5fbdfeb-a8c3-42d5-812c-872d65588c82"), Range = 1, Value = 1412.00m, Percent = 7.5m, Competence = DateTime.Parse("01/01/2024") },
                new Inss { Id = new Guid("d91884b0-cc69-46e3-8e5f-89d4dcb4d39e"), Range = 2, Value = 2666.68m, Percent = 9m, Competence = DateTime.Parse("01/01/2024") },
                new Inss { Id = new Guid("e5545b95-0f49-457d-a958-f4bc65caa6cd"), Range = 3, Value = 4000.03m, Percent = 12m, Competence = DateTime.Parse("01/01/2024") },
                new Inss { Id = new Guid("eb204e7a-5a7f-44e0-9224-833b74f4c173"), Range = 4, Value = 7786.02m, Percent = 14m, Competence = DateTime.Parse("01/01/2024") },
                new Inss { Id = new Guid("f5c4d84a-2e79-47ea-9949-e9f4ede99ce8"), Range = 1, Value = 1518.00m, Percent = 7.5m, Competence = DateTime.Parse("01/01/2025") },
                new Inss { Id = new Guid("fd49c72a-8b9d-4221-a144-0acc75ab3b44"), Range = 2, Value = 2793.88m, Percent = 9m, Competence = DateTime.Parse("01/01/2025") },
                new Inss { Id = new Guid("ff88a34a-9fa4-47b6-996e-41bb5c9bd374"), Range = 3, Value = 4190.83m, Percent = 12m, Competence = DateTime.Parse("01/01/2025") },
                new Inss { Id = new Guid("ff8b28ec-a94f-4291-ae7d-2ac3de353ce1"), Range = 4, Value = 8157.41m, Percent = 14m, Competence = DateTime.Parse("01/01/2025") }
            );
    }
}