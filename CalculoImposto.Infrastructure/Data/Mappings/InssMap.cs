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
        builder.Property(x => x.Competencia)
            .HasColumnType("DATE")
            .IsRequired();
        builder.Property(x => x.Valor)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();
        builder.Property(x => x.Faixa)
            .HasColumnType("INTEGER")
            .IsRequired();
        builder.Property(x => x.Porcentagem)
            .HasColumnType("DECIMAL(5,2)")
            .IsRequired();
    }
}