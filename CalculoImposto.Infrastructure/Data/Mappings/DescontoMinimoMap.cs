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
        builder.HasData(new DescontoMinimo { Id = new Guid("7f1b5cb3-cc50-4b61-a069-23c8405ff803"), Value = 10m, Competence = DateTime.Parse("01/05/2023") });
    }
}
