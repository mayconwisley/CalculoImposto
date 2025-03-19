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
        builder.Property(x => x.Competencia)
            .HasColumnType("DATE")
            .IsRequired();
        builder.Property(x => x.Valor)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();
    }
}
