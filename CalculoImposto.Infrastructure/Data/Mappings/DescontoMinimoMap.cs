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
        builder.Property(x => x.Competence)
            .HasColumnType("DATE")
            .IsRequired();
        builder.Property(x => x.Value)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();
        builder.HasData(new DescontoMinimo { Id = Guid.NewGuid(), Value = 10m, Competence = DateTime.Parse("01/05/2023") });
    }
}
