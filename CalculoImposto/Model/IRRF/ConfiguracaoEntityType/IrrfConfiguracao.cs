using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalculoImposto.API.Model.IRRF.ConfiguracaoEntityType;

public class IrrfConfiguracao : IEntityTypeConfiguration<IrrfModel>
{
    public void Configure(EntityTypeBuilder<IrrfModel> builder)
    {
        builder.Property(p => p.Faixa)
            .IsRequired();
        builder.Property(p => p.Valor)
           .HasColumnType("DECIMAL(18,2)")
           .IsRequired();
        builder.Property(p => p.Porcentagem)
               .HasColumnType("DECIMAL(7,4)")
               .IsRequired();
        builder.Property(p => p.Deducao)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();
    }
}
