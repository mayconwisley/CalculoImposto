using CalculoImposto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalculoImposto.Infrastructure.Data.Mappings;

public class DescontoMinimoMap : IEntityTypeConfiguration<DescontoMinimo>
{
    public void Configure(EntityTypeBuilder<DescontoMinimo> builder)
    {
        builder.ToTable("DescontoMinimo");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Competencia)
            .HasColumnType("DATE")
            .IsRequired();
        builder.Property(x => x.Valor)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();
    }
}
