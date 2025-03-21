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
              new Irrf { Id = new Guid("145774d6-2289-42d0-9060-2cb73a3681c6"), Range = 1, Value = 1903.98m, Percent = 0, Deduction = 0, Competence = DateTime.Parse("01/01/2015") },
              new Irrf { Id = new Guid("19833513-67a2-4db5-91f5-ec212bd5e397"), Range = 2, Value = 2826.65m, Percent = 7.50m, Deduction = 142.80m, Competence = DateTime.Parse("01/01/2015") },
              new Irrf { Id = new Guid("23dcc1ce-cdff-424a-ba82-caf29591244c"), Range = 3, Value = 3751.05m, Percent = 15m, Deduction = 354.80m, Competence = DateTime.Parse("01/01/2015") },
              new Irrf { Id = new Guid("3d6487f9-8c14-475a-bda2-8346ca65baaa"), Range = 4, Value = 4664.68m, Percent = 22.50m, Deduction = 636.13m, Competence = DateTime.Parse("01/01/2015") },
              new Irrf { Id = new Guid("473a63a2-b1a0-4721-bee4-5fbc3d27a7e3"), Range = 5, Value = 99999999999.99m, Percent = 27.50m, Deduction = 869.36m, Competence = DateTime.Parse("01/01/2015") },
              new Irrf { Id = new Guid("5489d21d-c596-486e-a506-e77589fc9989"), Range = 1, Value = 2112.00m, Percent = 0, Deduction = 0, Competence = DateTime.Parse("01/05/2023") },
              new Irrf { Id = new Guid("7468fb2e-58bb-4e4b-bbc6-9de0e87438ea"), Range = 2, Value = 2826.65m, Percent = 7.50m, Deduction = 158.40m, Competence = DateTime.Parse("01/05/2023") },
              new Irrf { Id = new Guid("7d50c7d0-6576-4f6c-b348-017062ad5837"), Range = 3, Value = 3751.05m, Percent = 15m, Deduction = 370.40m, Competence = DateTime.Parse("01/05/2023") },
              new Irrf { Id = new Guid("9c978ea5-472a-4e71-a082-73a5d5d99b74"), Range = 4, Value = 4664.68m, Percent = 22.50m, Deduction = 651.73m, Competence = DateTime.Parse("01/05/2023") },
              new Irrf { Id = new Guid("9fe85d20-3fd8-4e62-90ba-2807eaa9abf3"), Range = 5, Value = 99999999999.99m, Percent = 27.50m, Deduction = 884.96m, Competence = DateTime.Parse("01/05/2023") },
              new Irrf { Id = new Guid("a7df5997-6db5-4a51-8da1-a0703ac05ecd"), Range = 1, Value = 2259.20m, Percent = 0, Deduction = 0, Competence = DateTime.Parse("01/02/2024") },
              new Irrf { Id = new Guid("affd90a2-0372-45ff-af40-ee69d3e343a0"), Range = 2, Value = 2826.65m, Percent = 7.50m, Deduction = 169.44m, Competence = DateTime.Parse("01/02/2024") },
              new Irrf { Id = new Guid("bcab32f7-35f1-4dc4-898c-2d36ee0af95c"), Range = 3, Value = 3751.05m, Percent = 15m, Deduction = 381.44m, Competence = DateTime.Parse("01/02/2024") },
              new Irrf { Id = new Guid("eed864b0-2bc9-455c-beb8-bae000da7077"), Range = 4, Value = 4664.68m, Percent = 22.50m, Deduction = 662.77m, Competence = DateTime.Parse("01/02/2024") },
              new Irrf { Id = new Guid("f544a765-e333-4242-aa9a-c7bece8efed8"), Range = 5, Value = 99999999999.99m, Percent = 27.50m, Deduction = 896.00m, Competence = DateTime.Parse("01/02/2024") });
    }
}
