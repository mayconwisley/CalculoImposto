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
        builder.Property(x => x.Competence)
            .HasColumnType("DATE")
            .IsRequired();
        builder.Property(x => x.Value)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();

        builder.HasData(new Dependente { Id = new Guid("b8738c50-3292-4ecb-af01-57cb7d62f97a"), Value = 189.59m, Competence = DateTime.Parse("01/01/2015") });
    }
}
