using CalculoImposto.API.Banco;
using CalculoImposto.API.Model.IRRF;
using CalculoImposto.API.Repositorio.IRRF.Interface;
using Microsoft.EntityFrameworkCore;

namespace CalculoImposto.API.Repositorio.IRRF;

public class DependenteRepositorio(CalculoImpostoContext calculoImpostoContext) : IDependenteRepositorio
{
    private readonly CalculoImpostoContext _calculoImpostoContext = calculoImpostoContext;

    public async Task<DependenteModel> AtualizarDependente(DependenteModel dependente)
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
    public async Task<DependenteModel> CriarDependente(DependenteModel dependente)
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
    public async Task<DependenteModel> DeletarDependente(int id)
    {
        try
        {
            var dependente = await PegarPorIdDependente(id);
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
    public async Task<DependenteModel> PegarPorIdDependente(int id)
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

    public async Task<IEnumerable<DependenteModel>> PegarTodosDependente(int pagina, int tamanho, string busca)
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
            .Where(w => w.Competencia == competencia)
            .MaxAsync(w => w.Valor);
        return valorDependente;
    }
}
