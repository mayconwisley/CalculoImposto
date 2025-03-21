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
                new Inss { Id = Guid.NewGuid(), Range = 1, Value = 1045.00m, Percent = 7.5m, Competence = DateTime.Parse("01/03/2020") },
                new Inss { Id = Guid.NewGuid(), Range = 2, Value = 2089.60m, Percent = 9m, Competence = DateTime.Parse("01/03/2020") },
                new Inss { Id = Guid.NewGuid(), Range = 3, Value = 3134.40m, Percent = 12m, Competence = DateTime.Parse("01/03/2020") },
                new Inss { Id = Guid.NewGuid(), Range = 4, Value = 6101.06m, Percent = 14m, Competence = DateTime.Parse("01/03/2020") },
                new Inss { Id = Guid.NewGuid(), Range = 1, Value = 1100.00m, Percent = 7.5m, Competence = DateTime.Parse("01/03/2021") },
                new Inss { Id = Guid.NewGuid(), Range = 2, Value = 2203.45m, Percent = 9m, Competence = DateTime.Parse("01/03/2021") },
                new Inss { Id = Guid.NewGuid(), Range = 3, Value = 3305.22m, Percent = 12m, Competence = DateTime.Parse("01/03/2021") },
                new Inss { Id = Guid.NewGuid(), Range = 4, Value = 6433.57m, Percent = 14m, Competence = DateTime.Parse("01/03/2021") },
                new Inss { Id = Guid.NewGuid(), Range = 1, Value = 1212.00m, Percent = 7.5m, Competence = DateTime.Parse("01/01/2022") },
                new Inss { Id = Guid.NewGuid(), Range = 2, Value = 2452.67m, Percent = 9m, Competence = DateTime.Parse("01/01/2022") },
                new Inss { Id = Guid.NewGuid(), Range = 3, Value = 3679.00m, Percent = 12m, Competence = DateTime.Parse("01/01/2022") },
                new Inss { Id = Guid.NewGuid(), Range = 4, Value = 7087.22m, Percent = 14m, Competence = DateTime.Parse("01/01/2022") },
                new Inss { Id = Guid.NewGuid(), Range = 1, Value = 1302.00m, Percent = 7.5m, Competence = DateTime.Parse("01/01/2023") },
                new Inss { Id = Guid.NewGuid(), Range = 2, Value = 2571.29m, Percent = 9m, Competence = DateTime.Parse("01/01/2023") },
                new Inss { Id = Guid.NewGuid(), Range = 3, Value = 3856.94m, Percent = 12m, Competence = DateTime.Parse("01/01/2023") },
                new Inss { Id = Guid.NewGuid(), Range = 4, Value = 7507.49m, Percent = 14m, Competence = DateTime.Parse("01/01/2023") },
                new Inss { Id = Guid.NewGuid(), Range = 1, Value = 1320.00m, Percent = 7.5m, Competence = DateTime.Parse("01/05/2023") },
                new Inss { Id = Guid.NewGuid(), Range = 2, Value = 2571.29m, Percent = 9m, Competence = DateTime.Parse("01/05/2023") },
                new Inss { Id = Guid.NewGuid(), Range = 3, Value = 3856.94m, Percent = 12m, Competence = DateTime.Parse("01/05/2023") },
                new Inss { Id = Guid.NewGuid(), Range = 4, Value = 7507.49m, Percent = 14m, Competence = DateTime.Parse("01/05/2023") },
                new Inss { Id = Guid.NewGuid(), Range = 1, Value = 1412.00m, Percent = 7.5m, Competence = DateTime.Parse("01/01/2024") },
                new Inss { Id = Guid.NewGuid(), Range = 2, Value = 2666.68m, Percent = 9m, Competence = DateTime.Parse("01/01/2024") },
                new Inss { Id = Guid.NewGuid(), Range = 3, Value = 4000.03m, Percent = 12m, Competence = DateTime.Parse("01/01/2024") },
                new Inss { Id = Guid.NewGuid(), Range = 4, Value = 7786.02m, Percent = 14m, Competence = DateTime.Parse("01/01/2024") },
                new Inss { Id = Guid.NewGuid(), Range = 1, Value = 1518.00m, Percent = 7.5m, Competence = DateTime.Parse("01/01/2025") },
                new Inss { Id = Guid.NewGuid(), Range = 2, Value = 2793.88m, Percent = 9m, Competence = DateTime.Parse("01/01/2025") },
                new Inss { Id = Guid.NewGuid(), Range = 3, Value = 4190.83m, Percent = 12m, Competence = DateTime.Parse("01/01/2025") },
                new Inss { Id = Guid.NewGuid(), Range = 4, Value = 8157.41m, Percent = 14m, Competence = DateTime.Parse("01/01/2025") }
            );
    }
}