using CalculoImposto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalculoImposto.Infrastructure.Data.Mappings;

public class DependenteMap : IEntityTypeConfiguration<Dependente>
{
    public void Configure(EntityTypeBuilder<Dependente> builder)
    {
        builder.ToTable("Dependente");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Competencia)
            .HasColumnType("DATE")
            .IsRequired();
        builder.Property(x => x.Valor)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();
    }
}
