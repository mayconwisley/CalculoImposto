using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalculoImposto.API.Model.IRRF.ConfiguracaoEntityType;

public class DependenteConfiguracao : IEntityTypeConfiguration<DependenteModel>
{
    public void Configure(EntityTypeBuilder<DependenteModel> builder)
    {
        builder.Property(p => p.Competencia)
            .HasColumnType("DATETIME")
            .IsRequired();
        builder.Property(p => p.Valor)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();
    }
}
