using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalculoImposto.API.Model.IRRF.ConfiguracaoEntityType;

public class DescontoMinimoConfiguracai : IEntityTypeConfiguration<DescontoMinimoModel>
{
    public void Configure(EntityTypeBuilder<DescontoMinimoModel> builder)
    {
        builder.Property(p => p.Competencia)
        .HasColumnType("DATETIME")
        .IsRequired();
        builder.Property(p => p.Valor)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();
    }
}
