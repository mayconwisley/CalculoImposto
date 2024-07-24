using CalculoImposto.API.Banco;
using CalculoImposto.API.CRUD;
using CalculoImposto.API.Model.IRRF;
using CalculoImposto.API.Repositorio.IRRF.Interface;
using Microsoft.EntityFrameworkCore;

namespace CalculoImposto.API.Repositorio.IRRF;

public class DependenteRepositorio : CrudBase<DependenteModel>, IDependenteRepositorio
{
    private readonly CalculoImpostoContext _calculoImpostoContext;

    public DependenteRepositorio(CalculoImpostoContext calculoImpostoContext) : base(calculoImpostoContext)
    {
        _calculoImpostoContext = calculoImpostoContext;
    }


    public new async Task<DependenteModel> Atualizar(DependenteModel dependente)
    {
        try
        {
            if (dependente is not null)
            {
                _calculoImpostoContext.Dependentes.Entry(dependente).State = EntityState.Modified;
                await _calculoImpostoContext.SaveChangesAsync();
                return dependente;
            }
            return new();
        }
        catch (Exception)
        {

            throw;
        }
    }
    public new async Task<DependenteModel> Criar(DependenteModel dependente)
    {
        try
        {
            if (dependente is not null)
            {
                _calculoImpostoContext.Dependentes.Add(dependente);
                await _calculoImpostoContext.SaveChangesAsync();
                return dependente;
            }
            return new();
        }
        catch (Exception)
        {

            throw;
        }
    }
    public new async Task<DependenteModel> Deletar(int id)
    {
        try
        {
            var dependente = await PegarPorId(id);
            if (dependente is not null)
            {
                _calculoImpostoContext.Dependentes.Remove(dependente);
                await _calculoImpostoContext.SaveChangesAsync();
                return dependente;
            }
            return new();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<DependenteModel> PegarPorCompetenciaDependente(DateTime competencia)
    {
        try
        {
            var dependente = await _calculoImpostoContext.Dependentes
                .Where(w => w.Competencia == competencia)
                .FirstOrDefaultAsync();

            if (dependente is not null)
            {
                return dependente;
            }

            return new();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public new async Task<DependenteModel> PegarPorId(int id)
    {
        try
        {
            var dependente = await _calculoImpostoContext.Dependentes
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();

            if (dependente is not null)
            {
                return dependente;
            }
            return new();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public new async Task<IEnumerable<DependenteModel>> PegarTodos(int pagina, int tamanho)
    {
        try
        {
            var dependenteList = await _calculoImpostoContext.Dependentes
                .Skip((pagina - 1) * tamanho)
                .Take(tamanho)
                .OrderByDescending(w => w.Competencia)
                .ToListAsync();

            return dependenteList;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<int> TotalDependente()
    {
        var totalDependente = await _calculoImpostoContext.Dependentes
             .CountAsync();
        return totalDependente;
    }

    public async Task<decimal> ValorDependenteCompetencia(DateTime competencia)
    {
        var valorDependente = await _calculoImpostoContext.Dependentes
            .Where(w => w.Competencia == _calculoImpostoContext.Dependentes
                                         .Where(w => w.Competencia <= competencia)
                                         .Max(m => m.Competencia))
            .MaxAsync(w => w.Valor);
        return valorDependente;
    }
}
