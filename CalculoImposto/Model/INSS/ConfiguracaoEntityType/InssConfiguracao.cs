using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalculoImposto.API.Model.INSS.ConfiguracaoEntityType;

public class InssConfiguracao : IEntityTypeConfiguration<InssModel>
{
    public void Configure(EntityTypeBuilder<InssModel> builder)
    {
        builder.Property(p => p.Faixa)
               .IsRequired();
        builder.Property(p => p.Valor)
           .HasColumnType("DECIMAL(18,2)")
           .IsRequired();
        builder.Property(p => p.Porcentagem)
            .HasColumnType("DECIMAL(7,4)")
            .IsRequired();
    }
}
