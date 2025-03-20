using CalculoImposto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalculoImposto.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Inss> Inss { get; set; } = null!;
    public DbSet<Irrf> Irrf { get; set; } = null!;
    public DbSet<Dependente> Dependentes { get; set; } = null!;
    public DbSet<DescontoMinimo> DescontoMinimos { get; set; } = null!;
    public DbSet<Simplificado> Simplificados { get; set; } = null!;

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
    }
}
