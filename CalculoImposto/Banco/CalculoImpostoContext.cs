using CalculoImposto.API.Model.INSS;
using CalculoImposto.API.Model.IRRF;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CalculoImposto.API.Banco;

public class CalculoImpostoContext(DbContextOptions<CalculoImpostoContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<InssModel> INSS { get; set; }
    public DbSet<IrrfModel> IRRF { get; set; }
    public DbSet<DependenteModel> Dependentes { get; set; }
    public DbSet<DescontoMinimoModel> DescontoMinimos { get; set; }
    public DbSet<SimplificadoModel> Simplificados { get; set; }
}
