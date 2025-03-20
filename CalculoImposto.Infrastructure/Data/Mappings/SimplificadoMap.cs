using CalculoImposto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalculoImposto.Infrastructure.Data.Mappings;

public class SimplificadoMap : IEntityTypeConfiguration<Simplificado>
{
    public void Configure(EntityTypeBuilder<Simplificado> builder)
    {
        builder.ToTable("Simplificado");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Competence)
            .HasColumnType("DATE")
            .IsRequired();
        builder.Property(x => x.Value)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();
        builder.HasData(
            new Simplificado { Id = Guid.NewGuid(), Value = 528.00m, Competence = DateTime.Parse("01/05/2023") },
            new Simplificado { Id = Guid.NewGuid(), Value = 564.80m, Competence = DateTime.Parse("01/02/2024") });
    }
}
