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
            new Simplificado { Id = new Guid("300ec55a-a5b0-411b-be64-627db7608037"), Value = 528.00m, Competence = DateTime.Parse("01/05/2023") },
            new Simplificado { Id = new Guid("9db4331e-9735-403d-b2f7-6bbeb8942556"), Value = 564.80m, Competence = DateTime.Parse("01/02/2024") });
    }
}
