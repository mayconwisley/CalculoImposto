using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalculoImposto.API.Model.IRRF.ConfiguracaoEntityType;

public class SimplificadoConfiguracao : IEntityTypeConfiguration<SimplificadoModel>
{
    public void Configure(EntityTypeBuilder<SimplificadoModel> builder)
    {
        builder.Property(p => p.Competencia)
        .HasColumnType("DATETIME")
        .IsRequired();
        builder.Property(p => p.Valor)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();
    }
}
