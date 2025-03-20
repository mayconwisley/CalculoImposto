using CalculoImposto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalculoImposto.Infrastructure.Data.Mappings;

public class IrrfMap : IEntityTypeConfiguration<Irrf>
{
    public void Configure(EntityTypeBuilder<Irrf> builder)
    {
        builder.ToTable("Irrf");
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
        builder.Property(x => x.Deduction)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();
        builder.HasData(
              new Irrf { Id = Guid.NewGuid(), Range = 1, Value = 1903.98m, Percent = 0, Deduction = 0, Competence = DateTime.Parse("01/01/2015") },
              new Irrf { Id = Guid.NewGuid(), Range = 2, Value = 2826.65m, Percent = 7.50m, Deduction = 142.80m, Competence = DateTime.Parse("01/01/2015") },
              new Irrf { Id = Guid.NewGuid(), Range = 3, Value = 3751.05m, Percent = 15m, Deduction = 354.80m, Competence = DateTime.Parse("01/01/2015") },
              new Irrf { Id = Guid.NewGuid(), Range = 4, Value = 4664.68m, Percent = 22.50m, Deduction = 636.13m, Competence = DateTime.Parse("01/01/2015") },
              new Irrf { Id = Guid.NewGuid(), Range = 5, Value = 99999999999.99m, Percent = 27.50m, Deduction = 869.36m, Competence = DateTime.Parse("01/01/2015") },
              new Irrf { Id = Guid.NewGuid(), Range = 1, Value = 2112.00m, Percent = 0, Deduction = 0, Competence = DateTime.Parse("01/05/2023") },
              new Irrf { Id = Guid.NewGuid(), Range = 2, Value = 2826.65m, Percent = 7.50m, Deduction = 158.40m, Competence = DateTime.Parse("01/05/2023") },
              new Irrf { Id = Guid.NewGuid(), Range = 3, Value = 3751.05m, Percent = 15m, Deduction = 370.40m, Competence = DateTime.Parse("01/05/2023") },
              new Irrf { Id = Guid.NewGuid(), Range = 4, Value = 4664.68m, Percent = 22.50m, Deduction = 651.73m, Competence = DateTime.Parse("01/05/2023") },
              new Irrf { Id = Guid.NewGuid(), Range = 5, Value = 99999999999.99m, Percent = 27.50m, Deduction = 884.96m, Competence = DateTime.Parse("01/05/2023") },
              new Irrf { Id = Guid.NewGuid(), Range = 1, Value = 2259.20m, Percent = 0, Deduction = 0, Competence = DateTime.Parse("01/02/2024") },
              new Irrf { Id = Guid.NewGuid(), Range = 2, Value = 2826.65m, Percent = 7.50m, Deduction = 169.44m, Competence = DateTime.Parse("01/02/2024") },
              new Irrf { Id = Guid.NewGuid(), Range = 3, Value = 3751.05m, Percent = 15m, Deduction = 381.44m, Competence = DateTime.Parse("01/02/2024") },
              new Irrf { Id = Guid.NewGuid(), Range = 4, Value = 4664.68m, Percent = 22.50m, Deduction = 662.77m, Competence = DateTime.Parse("01/02/2024") },
              new Irrf { Id = Guid.NewGuid(), Range = 5, Value = 99999999999.99m, Percent = 27.50m, Deduction = 896.00m, Competence = DateTime.Parse("01/02/2024") });
    }
}
